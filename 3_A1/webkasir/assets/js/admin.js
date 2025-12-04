// Admin State
let currentStatus = "pending"
let orders = []

// Initialize
document.addEventListener("DOMContentLoaded", () => {
  setCurrentDate()
  loadOrders()
  setupEventListeners()

  // Auto refresh every 30 seconds
  setInterval(loadOrders, 30000)
})

function setCurrentDate() {
  const options = { weekday: "long", year: "numeric", month: "long", day: "numeric" }
  const today = new Date().toLocaleDateString("id-ID", options)
  document.getElementById("current-date").textContent = today
}

function setupEventListeners() {
  // Filter tabs
  document.querySelectorAll(".filter-tab").forEach((tab) => {
    tab.addEventListener("click", function () {
      document.querySelectorAll(".filter-tab").forEach((t) => t.classList.remove("active"))
      this.classList.add("active")
      currentStatus = this.dataset.status
      renderOrders()
    })
  })
}

async function loadOrders() {
  try {
    // Load all status counts
    const [pending, approved, rejected] = await Promise.all([
      fetch("api/antrian.php?status=pending").then((r) => r.json()),
      fetch("api/antrian.php?status=approved").then((r) => r.json()),
      fetch("api/antrian.php?status=rejected").then((r) => r.json()),
    ])

    document.getElementById("pending-count").textContent = pending.data?.length || 0
    document.getElementById("approved-count").textContent = approved.data?.length || 0
    document.getElementById("rejected-count").textContent = rejected.data?.length || 0

    // Combine all orders
    orders = [
      ...(pending.data || []).map((o) => ({ ...o, status: "pending" })),
      ...(approved.data || []).map((o) => ({ ...o, status: "approved" })),
      ...(rejected.data || []).map((o) => ({ ...o, status: "rejected" })),
    ]

    renderOrders()
  } catch (error) {
    console.error("Error loading orders:", error)
    showToast("Gagal memuat data pesanan", "error")
  }
}

function renderOrders() {
  const container = document.getElementById("orders-list")
  const filteredOrders = orders.filter((o) => o.status === currentStatus)

  if (filteredOrders.length === 0) {
    const messages = {
      pending: "Tidak ada pesanan yang menunggu persetujuan",
      approved: "Belum ada pesanan yang disetujui",
      rejected: "Tidak ada pesanan yang ditolak",
    }

    container.innerHTML = `
            <div class="empty-state">
                <div class="empty-state-icon">
                    <svg xmlns="http://www.w3.org/2000/svg" width="40" height="40" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"><path d="M21 8a2 2 0 0 0-1-1.73l-7-4a2 2 0 0 0-2 0l-7 4A2 2 0 0 0 3 8v8a2 2 0 0 0 1 1.73l7 4a2 2 0 0 0 2 0l7-4A2 2 0 0 0 21 16Z"/><path d="m3.3 7 8.7 5 8.7-5"/><path d="M12 22V12"/></svg>
                </div>
                <h3>Tidak Ada Pesanan</h3>
                <p>${messages[currentStatus]}</p>
            </div>
        `
    return
  }

  container.innerHTML = filteredOrders
    .map(
      (order) => `
        <div class="order-card" data-id="${order.id_antrian}">
            <div class="order-card-header">
                <div class="order-info">
                    <span class="order-number">Pesanan #${order.id_antrian}</span>
                    <span class="order-time">
                        <svg xmlns="http://www.w3.org/2000/svg" width="14" height="14" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><circle cx="12" cy="12" r="10"/><polyline points="12 6 12 12 16 14"/></svg>
                        ${formatDateTime(order.tanggal_pesan)}
                    </span>
                </div>
                <span class="order-status ${order.status}">${getStatusLabel(order.status)}</span>
            </div>
            <div class="order-card-body">
                ${
                  order.nama_pembeli
                    ? `
                <div class="order-customer">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M20 21v-2a4 4 0 0 0-4-4H8a4 4 0 0 0-4 4v2"/><circle cx="12" cy="7" r="4"/></svg>
                    <span>${order.nama_pembeli}</span>
                </div>
                `
                    : ""
                }
                <div class="order-summary">
                    <div class="order-summary-item">
                        <span class="order-summary-label">Metode Bayar</span>
                        <span class="order-summary-value">${order.metode_pembayaran.toUpperCase()}</span>
                    </div>
                    <div class="order-summary-item">
                        <span class="order-summary-label">Total</span>
                        <span class="order-summary-value total">${formatCurrency(order.total)}</span>
                    </div>
                </div>
                <div class="order-actions">
                    <button class="order-btn view" onclick="viewOrder(${order.id_antrian})">
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M2 12s3-7 10-7 10 7 10 7-3 7-10 7-10-7-10-7Z"/><circle cx="12" cy="12" r="3"/></svg>
                        Detail
                    </button>
                    ${
                      order.status === "pending"
                        ? `
                        <button class="order-btn approve" onclick="approveOrder(${order.id_antrian})">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><polyline points="20 6 9 17 4 12"/></svg>
                            Setujui
                        </button>
                        <button class="order-btn reject" onclick="showRejectModal(${order.id_antrian})">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><line x1="18" y1="6" x2="6" y2="18"/><line x1="6" y1="6" x2="18" y2="18"/></svg>
                            Tolak
                        </button>
                    `
                        : ""
                    }
                </div>
            </div>
        </div>
    `,
    )
    .join("")
}

async function viewOrder(id) {
  try {
    const response = await fetch(`api/antrian.php?id=${id}`)
    const result = await response.json()

    if (!result.success) {
      showToast(result.message, "error")
      return
    }

    const order = result.data
    const modal = document.getElementById("order-modal")
    const content = document.getElementById("order-detail-content")

    document.getElementById("order-id").textContent = `#${order.id_antrian}`

    content.innerHTML = `
            <div class="order-detail-header">
                <div class="order-detail-info">
                    <h4>Pesanan #${order.id_antrian}</h4>
                    <p>${formatDateTime(order.tanggal_pesan)}</p>
                </div>
                <span class="order-status ${order.status}">${getStatusLabel(order.status)}</span>
            </div>
            
            ${
              order.nama_pembeli
                ? `
            <div class="order-customer-detail">
                <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M20 21v-2a4 4 0 0 0-4-4H8a4 4 0 0 0-4 4v2"/><circle cx="12" cy="7" r="4"/></svg>
                <div>
                    <span class="customer-label">Nama Pembeli</span>
                    <span class="customer-name">${order.nama_pembeli}</span>
                </div>
            </div>
            `
                : ""
            }
            
            <div class="order-items-list">
                <h5>Daftar Item</h5>
                ${order.items
                  .map(
                    (item) => `
                    <div class="order-item">
                        <div class="order-item-info">
                            <span class="order-item-name">${item.nama_barang}</span>
                            <span class="order-item-qty">${item.jumlah} x ${formatCurrency(item.harga)}</span>
                        </div>
                        <span class="order-item-price">${formatCurrency(item.subtotal)}</span>
                    </div>
                `,
                  )
                  .join("")}
            </div>
            
            <div class="order-payment-info">
                <div class="order-payment-row">
                    <span>Metode Pembayaran</span>
                    <span>${order.metode_pembayaran.toUpperCase()}</span>
                </div>
                <div class="order-payment-row">
                    <span>Jumlah Dibayar</span>
                    <span>${formatCurrency(order.jumlah_bayar)}</span>
                </div>
                <div class="order-payment-row">
                    <span>Kembalian</span>
                    <span>${formatCurrency(order.kembalian)}</span>
                </div>
                <div class="order-payment-row total">
                    <span>Total</span>
                    <span>${formatCurrency(order.total)}</span>
                </div>
            </div>
            
            ${
              order.status === "pending"
                ? `
                <div class="order-modal-actions">
                    <button class="order-btn approve" onclick="approveOrder(${order.id_antrian}); closeOrderModal();">
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><polyline points="20 6 9 17 4 12"/></svg>
                        Setujui Pesanan
                    </button>
                    <button class="order-btn reject" onclick="showRejectModal(${order.id_antrian}); closeOrderModal();">
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><line x1="18" y1="6" x2="6" y2="18"/><line x1="6" y1="6" x2="18" y2="18"/></svg>
                        Tolak Pesanan
                    </button>
                </div>
            `
                : ""
            }
            
            ${
              order.status === "rejected" && order.catatan
                ? `
                <div class="reject-note">
                    <strong>Alasan Penolakan:</strong>
                    <p>${order.catatan}</p>
                </div>
            `
                : ""
            }
        `

    modal.classList.add("active")
  } catch (error) {
    console.error("Error viewing order:", error)
    showToast("Gagal memuat detail pesanan", "error")
  }
}

function closeOrderModal() {
  document.getElementById("order-modal").classList.remove("active")
}

async function approveOrder(id) {
  if (!confirm("Setuju?")) return

  try {
    const response = await fetch("api/antrian.php", {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        id_antrian: id,
        status: "approved",
      }),
    })

    const result = await response.json()

    if (result.success) {
      showToast("Pesanan berhasil disetujui", "success")
      loadOrders()
    } else {
      showToast(result.message, "error")
    }
  } catch (error) {
    console.error("Error approving order:", error)
    showToast("Gagal menyetujui pesanan", "error")
  }
}

function showRejectModal(id) {
  const modal = document.getElementById("order-modal")
  const content = document.getElementById("order-detail-content")

  document.getElementById("order-id").textContent = `#${id}`

  content.innerHTML = `
        <div class="reject-reason">
            <label for="reject-note">Alasan Penolakan (Opsional)</label>
            <textarea id="reject-note" placeholder="Masukkan alasan penolakan pesanan..."></textarea>
        </div>
        <div class="order-modal-actions">
            <button class="order-btn view" onclick="closeOrderModal()">Batal</button>
            <button class="order-btn reject" onclick="rejectOrder(${id})">
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><line x1="18" y1="6" x2="6" y2="18"/><line x1="6" y1="6" x2="18" y2="18"/></svg>
                Konfirmasi Tolak
            </button>
        </div>
    `

  modal.classList.add("active")
}

async function rejectOrder(id) {
  const catatan = document.getElementById("reject-note")?.value || ""

  try {
    const response = await fetch("api/antrian.php", {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        id_antrian: id,
        status: "rejected",
        catatan: catatan,
      }),
    })

    const result = await response.json()

    if (result.success) {
      showToast("Pesanan ditolak", "success")
      closeOrderModal()
      loadOrders()
    } else {
      showToast(result.message, "error")
    }
  } catch (error) {
    console.error("Error rejecting order:", error)
    showToast("Gagal menolak pesanan", "error")
  }
}

// Utility Functions
function formatCurrency(amount) {
  return "Rp " + Number(amount).toLocaleString("id-ID")
}

function formatDateTime(dateStr) {
  const date = new Date(dateStr)
  const options = {
    day: "numeric",
    month: "short",
    year: "numeric",
    hour: "2-digit",
    minute: "2-digit",
  }
  return date.toLocaleDateString("id-ID", options)
}

function getStatusLabel(status) {
  const labels = {
    pending: "Menunggu",
    approved: "Disetujui",
    rejected: "Ditolak",
  }
  return labels[status] || status
}

function showToast(message, type = "success") {
  const container = document.getElementById("toast-container")
  const toast = document.createElement("div")
  toast.className = `toast ${type}`
  toast.innerHTML = `
        <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
            ${
              type === "success"
                ? '<path d="M22 11.08V12a10 10 0 1 1-5.93-9.14"/><polyline points="22 4 12 14.01 9 11.01"/>'
                : '<circle cx="12" cy="12" r="10"/><line x1="15" y1="9" x2="9" y2="15"/><line x1="9" y1="9" x2="15" y2="15"/>'
            }
        </svg>
        <span>${message}</span>
    `
  container.appendChild(toast)

  setTimeout(() => {
    toast.classList.add("hide")
    setTimeout(() => toast.remove(), 300)
  }, 3000)
}
