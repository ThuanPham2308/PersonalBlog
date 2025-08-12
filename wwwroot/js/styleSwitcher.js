const links = document.querySelectorAll('.alternate-style'),
    totalLinks = links.length;

function setActiveStyle(color) {
    for (let i = 0; i < totalLinks; i++) {
        if (color === links[i].getAttribute('title')) {
            links[i].removeAttribute('disabled');
        } else {
            links[i].setAttribute('disabled', true);
        }
    }
    // Lưu màu vào localStorage
    localStorage.setItem('selectedColor', color);
}

// Áp dụng màu đã lưu khi load trang
window.addEventListener('DOMContentLoaded', () => {
    const savedColor = localStorage.getItem('selectedColor');
    if (savedColor) {
        setActiveStyle(savedColor);
    }

    const savedSkin = localStorage.getItem('selectedSkin');
    if (savedSkin) {
        if (savedSkin === 'dark') {
            document.body.className = 'dark';
        } else {
            document.body.className = '';
        }

        // Cập nhật radio body skin đã chọn
        const radio = document.querySelector(`input.body-skin[value="${savedSkin}"]`);
        if (radio) radio.checked = true;
    }
});

// body skin
const bodySkin = document.querySelectorAll('.body-skin'),
    totalBodySkin = bodySkin.length;

for (let i = 0; i < totalBodySkin; i++) {
    bodySkin[i].addEventListener('change', function () {
        if (this.value === 'dark') {
            document.body.className = 'dark';
            localStorage.setItem('selectedSkin', 'dark');
        } else {
            document.body.className = '';
            localStorage.setItem('selectedSkin', 'light');
        }
    });
}

// Toggle style switcher panel
document.querySelector('.toggle-style-switcher').addEventListener('click', () => {
    document.querySelector('.style-switcher').classList.toggle('open');
});
