// State Management
const state = {
  products: [],
  categories: [],
  cart: JSON.parse(sessionStorage.getItem("cart")) || [],
  selectedCategory: "",
  searchQuery: "",
}

// DOM Elements
const productsGrid = document.getElementById("products-grid")
const cartItems = document.getElementById("cart-items")
const cartCount = document.getElementById("cart-count")
const cartSubtotal = document.getElementById("cart-subtotal")
const cartTotal = document.getElementById("cart-total")
const checkoutBtn = document.getElementById("checkout-btn")
const searchInput = document.getElementById("search-input")
const categoryFilter = document.getElementById("category-filter")
const categoryPills = document.getElementById("category-pills")
const currentDateEl = document.getElementById("current-date")

const navSidebar = document.getElementById("nav-sidebar")
const cartSidebar = document.getElementById("cart-sidebar")
const sidebarOverlay = document.getElementById("sidebar-overlay")
const cartOverlay = document.getElementById("cart-overlay")
const hamburgerBtn = document.getElementById("hamburger-btn")
const navCloseBtn = document.getElementById("nav-close-btn")
const mobileCartBtn = document.getElementById("mobile-cart-btn")
const cartCloseBtn = document.getElementById("cart-close-btn")
const clearCartBtn = document.getElementById("clear-cart-btn")

// Payment state
let currentPaymentTotal = 0

// Initialize
document.addEventListener("DOMContentLoaded", () => {
  loadCategories()
  loadProducts()
  updateCart()
  setupEventListeners()
  updateCurrentDate()
})

function updateCurrentDate() {
  const options = { weekday: "long", year: "numeric", month: "long", day: "numeric" }
  const today = new Date()
  if (currentDateEl) {
    currentDateEl.textContent = today.toLocaleDateString("id-ID", options)
  }
}

// Event Listeners
function setupEventListeners() {
  searchInput.addEventListener("input", debounce(handleSearch, 300))
  categoryFilter.addEventListener("change", handleCategoryChange)
  checkoutBtn.addEventListener("click", () => {
    const total = state.cart.reduce((sum, item) => sum + item.harga_jual * item.quantity, 0)
    openPaymentModal(total)
  })

  if (hamburgerBtn) {
    hamburgerBtn.addEventListener("click", openNavSidebar)
  }

  if (navCloseBtn) {
    navCloseBtn.addEventListener("click", closeNavSidebar)
  }

  if (sidebarOverlay) {
    sidebarOverlay.addEventListener("click", closeNavSidebar)
  }

  if (mobileCartBtn) {
    mobileCartBtn.addEventListener("click", openCart)
  }

  if (cartCloseBtn) {
    cartCloseBtn.addEventListener("click", closeCart)
  }

  if (cartOverlay) {
    cartOverlay.addEventListener("click", closeCart)
  }

  if (clearCartBtn) {
    clearCartBtn.addEventListener("click", () => {
      if (state.cart.length > 0 && confirm("Kosongkan semua item dari keranjang?")) {
        clearCart()
        showToast("Keranjang dikosongkan")
      }
    })
  }

  setupPaymentModalListeners()
}

function openNavSidebar() {
  if (navSidebar) {
    navSidebar.classList.add("open")
  }
  if (sidebarOverlay) {
    sidebarOverlay.classList.add("active")
  }
  document.body.style.overflow = "hidden"
}

function closeNavSidebar() {
  if (navSidebar) {
    navSidebar.classList.remove("open")
  }
  if (sidebarOverlay) {
    sidebarOverlay.classList.remove("active")
  }
  document.body.style.overflow = ""
}

function openCart() {
  if (cartSidebar) {
    cartSidebar.classList.add("open")
  }
  if (cartOverlay) {
    cartOverlay.classList.add("active")
  }
  document.body.style.overflow = "hidden"
}

function closeCart() {
  if (cartSidebar) {
    cartSidebar.classList.remove("open")
  }
  if (cartOverlay) {
    cartOverlay.classList.remove("active")
  }
  document.body.style.overflow = ""
}

function setupPaymentModalListeners() {
  // Close modal buttons
  const closePaymentModal = document.getElementById("close-payment-modal")
  if (closePaymentModal) {
    closePaymentModal.addEventListener("click", () => {
      document.getElementById("payment-modal").classList.remove("active")
    })
  }

  // Payment method selection
  document.querySelectorAll(".payment-method").forEach((method) => {
    method.addEventListener("click", function () {
      selectPaymentMethod(this.dataset.method)
    })
  })

  // New transaction button
  const newTransactionBtn = document.getElementById("new-transaction-btn")
  if (newTransactionBtn) {
    newTransactionBtn.addEventListener("click", () => {
      document.getElementById("success-modal").classList.remove("active")
      state.cart = []
      updateCart()
    })
  }

  // Close modal on overlay click
  document.querySelectorAll(".modal-overlay").forEach((overlay) => {
    overlay.addEventListener("click", function (e) {
      if (e.target === this) {
        this.classList.remove("active")
      }
    })
  })
}

// API Functions
async function loadProducts() {
  showLoading(productsGrid)

  try {
    const params = new URLSearchParams()

    if (state.selectedCategory) {
      params.append("kategori", state.selectedCategory)
    }
    if (state.searchQuery) {
      params.append("search", state.searchQuery)
    }

    const url = `api/barang.php${params.toString() ? "?" + params.toString() : ""}`

    const response = await fetch(url)
    const data = await response.json()

    if (data.success) {
      state.products = data.data
      renderProducts()
    }
  } catch (error) {
    console.error("Error loading products:", error)
    productsGrid.innerHTML = '<p class="error">Gagal memuat produk</p>'
  }
}

async function loadCategories() {
  try {
    const response = await fetch("api/kategori.php")
    const data = await response.json()

    if (data.success) {
      state.categories = data.data
      renderCategories()
      renderCategoryPills()
    }
  } catch (error) {
    console.error("Error loading categories:", error)
  }
}

// Render Functions
function renderProducts() {
  if (state.products.length === 0) {
    productsGrid.innerHTML = `
      <div class="cart-empty" style="grid-column: 1/-1;">
        <div class="cart-empty-icon">
          <svg xmlns="http://www.w3.org/2000/svg" width="48" height="48" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"><circle cx="11" cy="11" r="8"/><path d="m21 21-4.3-4.3"/></svg>
        </div>
        <p class="cart-empty-title">Produk tidak ditemukan</p>
        <p class="cart-empty-subtitle">Coba kata kunci lain atau pilih kategori berbeda</p>
      </div>
    `
    return
  }

  productsGrid.innerHTML = state.products
    .map(
      (product) => `
        <div class="product-card" onclick="addToCart('${product.kode_barang}')">
          <div class="product-image">
            ${
              product.gambar
                ? `<img src="api/gambar.php?path=${encodeURIComponent(product.gambar)}" alt="${product.nama_barang}" loading="lazy">`
                : `<span class="placeholder-icon">📦</span>`
            }
            <span class="stock-badge ${product.stok <= 5 ? "low" : ""}">
              Stok: ${product.stok}
            </span>
          </div>
          <div class="product-info">
            <span class="product-category">${product.nama_kategori || product.kategori || "Umum"}</span>
            <h3 class="product-name">${product.nama_barang}</h3>
            <p class="product-price">${formatCurrency(product.harga_jual)}</p>
          </div>
          <button class="add-btn" onclick="event.stopPropagation(); addToCart('${product.kode_barang}')">
            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M5 12h14"/><path d="M12 5v14"/></svg>
            Tambah
          </button>
        </div>
    `,
    )
    .join("")
}

function renderCategories() {
  categoryFilter.innerHTML = `
    <option value="">Semua Kategori</option>
    ${state.categories
      .map(
        (cat) => `
        <option value="${cat.kode_kategori}">${cat.nama_kategori}</option>
    `,
      )
      .join("")}
  `
}

function renderCategoryPills() {
  if (!categoryPills) return

  categoryPills.innerHTML = `
    <button class="category-pill ${state.selectedCategory === "" ? "active" : ""}" data-category="" onclick="selectCategoryPill('')">Semua</button>
    ${state.categories
      .map(
        (cat) => `
        <button class="category-pill ${state.selectedCategory === cat.kode_kategori ? "active" : ""}" data-category="${cat.kode_kategori}" onclick="selectCategoryPill('${cat.kode_kategori}')">${cat.nama_kategori}</button>
    `,
      )
      .join("")}
  `
}

function selectCategoryPill(categoryKode) {
  state.selectedCategory = categoryKode
  categoryFilter.value = categoryKode
  renderCategoryPills()
  loadProducts()
}

// Cart Functions
function addToCart(kodeBarang) {
  const product = state.products.find((p) => p.kode_barang === kodeBarang)
  if (!product) return

  const existingItem = state.cart.find((item) => item.kode_barang === kodeBarang)

  if (existingItem) {
    if (existingItem.quantity >= product.stok) {
      showToast("Stok tidak mencukupi", "error")
      return
    }
    existingItem.quantity++
  } else {
    state.cart.push({
      ...product,
      quantity: 1,
    })
  }

  updateCart()
  showToast(`${product.nama_barang} ditambahkan`, "success")

  if (window.innerWidth <= 768) {
    openCart()
  }
}

function updateQuantity(kodeBarang, change) {
  const item = state.cart.find((i) => i.kode_barang === kodeBarang)
  if (!item) return

  const product = state.products.find((p) => p.kode_barang === kodeBarang)
  const newQuantity = item.quantity + change

  if (newQuantity <= 0) {
    removeFromCart(kodeBarang)
    return
  }

  if (product && newQuantity > product.stok) {
    showToast("Stok tidak mencukupi", "error")
    return
  }

  item.quantity = newQuantity
  updateCart()
}

function removeFromCart(kodeBarang) {
  state.cart = state.cart.filter((item) => item.kode_barang !== kodeBarang)
  updateCart()
  showToast("Item dihapus dari keranjang")
}

function updateCart() {
  saveCart()
  renderCart()

  const totalItems = state.cart.reduce((sum, item) => sum + item.quantity, 0)
  const totalPrice = state.cart.reduce((sum, item) => sum + item.harga_jual * item.quantity, 0)

  cartCount.textContent = totalItems
  cartSubtotal.textContent = formatCurrency(totalPrice)
  cartTotal.textContent = formatCurrency(totalPrice)

  checkoutBtn.disabled = state.cart.length === 0

  const mobileCartBadge = document.getElementById("mobile-cart-badge")
  if (mobileCartBadge) {
    mobileCartBadge.textContent = totalItems
  }

  if (clearCartBtn) {
    clearCartBtn.style.display = state.cart.length > 0 ? "flex" : "none"
  }
}

function saveCart() {
  sessionStorage.setItem("cart", JSON.stringify(state.cart))
}

function clearCart() {
  state.cart = []
  updateCart()
}

// Search & Filter
function handleSearch(e) {
  state.searchQuery = e.target.value
  loadProducts()
}

function handleCategoryChange(e) {
  state.selectedCategory = e.target.value
  renderCategoryPills()
  loadProducts()
}

function openPaymentModal(total) {
  currentPaymentTotal = total

  const modal = document.getElementById("payment-modal")
  const modalTotal = document.getElementById("modal-total")
  const amountInput = document.getElementById("amount-paid")
  const changeDisplay = document.getElementById("change-display")
  const payBtn = document.getElementById("pay-btn")
  const cashForm = document.getElementById("cash-form")
  const qrisForm = document.getElementById("qris-form")

  // Set total
  modalTotal.textContent = formatCurrency(total)

  // Reset form
  amountInput.value = ""
  changeDisplay.style.display = "none"
  payBtn.disabled = true

  // Reset payment method to cash
  document.querySelectorAll(".payment-method").forEach((m) => m.classList.remove("active"))
  document.querySelector('.payment-method[data-method="cash"]').classList.add("active")
  cashForm.style.display = "block"
  qrisForm.style.display = "none"

  // Show modal
  modal.classList.add("active")

  // Focus on input
  setTimeout(() => amountInput.focus(), 100)
}

function selectPaymentMethod(method) {
  // Update active class
  document.querySelectorAll(".payment-method").forEach((m) => m.classList.remove("active"))
  document.querySelector(`.payment-method[data-method="${method}"]`).classList.add("active")

  const cashForm = document.getElementById("cash-form")
  const qrisForm = document.getElementById("qris-form")
  const payBtn = document.getElementById("pay-btn")

  if (method === "cash") {
    cashForm.style.display = "block"
    qrisForm.style.display = "none"
    // Re-calculate to update button state
    calculateChange()
  } else {
    cashForm.style.display = "none"
    qrisForm.style.display = "block"
    // QRIS - enable button immediately
    payBtn.disabled = false
  }
}

function calculateChange() {
  const amountInput = document.getElementById("amount-paid")
  const changeDisplay = document.getElementById("change-display")
  const changeAmount = document.getElementById("change-amount")
  const payBtn = document.getElementById("pay-btn")

  const amountPaid = Number.parseInt(amountInput.value) || 0
  const total = currentPaymentTotal

  // Always show change display when there's input
  if (amountPaid > 0) {
    changeDisplay.style.display = "block"

    if (amountPaid >= total) {
      // Enough money - enable button
      const change = amountPaid - total
      changeAmount.textContent = formatCurrency(change)
      changeDisplay.classList.remove("error")
      changeDisplay.classList.add("success")
      payBtn.disabled = false
    } else {
      // Not enough money - disable button
      const shortage = total - amountPaid
      changeAmount.textContent = `Kurang ${formatCurrency(shortage)}`
      changeDisplay.classList.add("error")
      changeDisplay.classList.remove("success")
      payBtn.disabled = true
    }
  } else {
    changeDisplay.style.display = "none"
    payBtn.disabled = true
  }
}

async function processPayment() {
  const payBtn = document.getElementById("pay-btn")

  // Prevent double click
  if (payBtn.disabled) return

  const total = currentPaymentTotal
  const activeMethod = document.querySelector(".payment-method.active")
  const method = activeMethod ? activeMethod.dataset.method : "cash"
  const amountInput = document.getElementById("amount-paid")
  const amountPaid = method === "cash" ? Number.parseInt(amountInput.value) || 0 : total

  const buyerNameInput = document.getElementById("buyer-name")
  const buyerName = buyerNameInput ? buyerNameInput.value.trim() : ""

  // Validate cash payment
  if (method === "cash" && amountPaid < total) {
    showToast("Jumlah uang tidak mencukupi", "error")
    return
  }

  // Disable button and show loading
  payBtn.disabled = true
  const originalText = payBtn.innerHTML
  payBtn.innerHTML = '<span class="spinner-small"></span> Memproses...'

  // Prepare order data - Add nama_pembeli to order data
  const orderData = {
    items: state.cart.map((item) => ({
      kode_barang: item.kode_barang,
      nama_barang: item.nama_barang,
      harga: item.harga_jual,
      jumlah: item.quantity,
      subtotal: item.harga_jual * item.quantity,
    })),
    total: total,
    metode_pembayaran: method,
    jumlah_bayar: amountPaid,
    kembalian: amountPaid - total,
    nama_pembeli: buyerName, // Added buyer name
  }

  try {
    const response = await fetch("api/antrian.php", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(orderData),
    })

    const result = await response.json()

    if (result.success) {
      // Close payment modal
      document.getElementById("payment-modal").classList.remove("active")

      // Show success modal
      const successModal = document.getElementById("success-modal")
      document.getElementById("transaction-id").textContent = `No. Antrian: ${result.id_antrian}`

      // Update success message
      const successContent = successModal.querySelector(".success-content")
      successContent.querySelector("h3").textContent = "Pesanan Dikirim!"
      successContent.querySelector("p").textContent = "Pesanan sedang menunggu persetujuan admin"

      successModal.classList.add("active")

      // Clear cart
      state.cart = []
      saveCart()
      updateCart()

      if (buyerNameInput) buyerNameInput.value = ""

      showToast("Pesanan berhasil dikirim ke antrian!", "success")
    } else {
      throw new Error(result.message || "Gagal menyimpan pesanan")
    }
  } catch (error) {
    console.error("Payment error:", error)
    showToast("Terjadi kesalahan: " + error.message, "error")
  } finally {
    payBtn.disabled = false
    payBtn.innerHTML = originalText
  }
}

// Render Cart
function renderCart() {
  if (state.cart.length === 0) {
    cartItems.innerHTML = `
      <div class="cart-empty">
        <div class="cart-empty-icon">
          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><polyline points="20 6 9 17 4 12"/></svg>
        </div>
        <p class="cart-empty-title">Belum ada pesanan</p>
        <p class="cart-empty-subtitle">Klik produk untuk menambahkan ke pesanan</p>
      </div>
    `
    if (clearCartBtn) clearCartBtn.style.display = "none"
    return
  }

  if (clearCartBtn) clearCartBtn.style.display = "flex"

  cartItems.innerHTML = state.cart
    .map(
      (item) => `
        <div class="cart-item">
          <div class="cart-item-image">
            ${item.gambar ? `<img src="api/gambar.php?path=${encodeURIComponent(item.gambar)}" alt="${item.nama_barang}">` : `📦`}
          </div>
          <div class="cart-item-info">
            <h4 class="cart-item-name">${item.nama_barang}</h4>
            <p class="cart-item-price">${formatCurrency(item.harga_jual)}</p>
            <div class="cart-item-actions">
              <button class="qty-btn" onclick="updateQuantity('${item.kode_barang}', -1)">−</button>
              <span class="qty-value">${item.quantity}</span>
              <button class="qty-btn" onclick="updateQuantity('${item.kode_barang}', 1)">+</button>
            </div>
          </div>
          <div class="cart-item-subtotal">
            <strong>${formatCurrency(item.harga_jual * item.quantity)}</strong>
            <button class="remove-btn" onclick="removeFromCart('${item.kode_barang}')">
              <svg xmlns="http://www.w3.org/2000/svg" width="14" height="14" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M3 6h18"/><path d="M19 6v14c0 1-1 2-2 2H7c-1 0-2-1-2-2V6"/><path d="M8 6V4c0-1 1-2 2-2h4c1 0 2 1 2 2v2"/></svg>
            </button>
          </div>
        </div>
    `,
    )
    .join("")
}

// Utility Functions
function formatCurrency(amount) {
  return new Intl.NumberFormat("id-ID", {
    style: "currency",
    currency: "IDR",
    minimumFractionDigits: 0,
    maximumFractionDigits: 0,
  }).format(amount)
}

function debounce(func, wait) {
  let timeout
  return function executedFunction(...args) {
    const later = () => {
      clearTimeout(timeout)
      func(...args)
    }
    clearTimeout(timeout)
    timeout = setTimeout(later, wait)
  }
}

function showLoading(container) {
  container.innerHTML = `
    <div class="loading" style="grid-column: 1/-1;">
      <div class="spinner"></div>
    </div>
  `
}

function showToast(message, type = "") {
  const existingToast = document.querySelector(".toast")
  if (existingToast) existingToast.remove()

  const toast = document.createElement("div")
  toast.className = `toast ${type}`
  toast.innerHTML = `
    ${type === "success" ? '<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><polyline points="20 6 9 17 4 12"/></svg>' : ""}
    ${type === "error" ? '<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><circle cx="12" cy="12" r="10"/><line x1="15" x2="9" y1="9" y2="15"/><line x1="9" x2="15" y1="9" y2="15"/></svg>' : ""}
    <span>${message}</span>
  `
  document.body.appendChild(toast)

  setTimeout(() => toast.classList.add("show"), 10)
  setTimeout(() => {
    toast.classList.remove("show")
    setTimeout(() => toast.remove(), 300)
  }, 3000)
}
