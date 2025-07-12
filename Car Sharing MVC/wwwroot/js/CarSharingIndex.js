document.addEventListener("DOMContentLoaded", function () {
    const backgroundUrl = 'https://img5.goodfon.ru/wallpaper/nbig/0/44/lamborghini-fon-mashina.jpg';
    const timestamp = new Date().getTime(); // Получаем текущее время в миллисекундах
    const img = new Image();
    img.src = `${backgroundUrl}?timestamp=${timestamp}`; // Добавляем случайный параметр в URL
    img.onload = function () {
        document.body.style.backgroundImage = `url(${backgroundUrl}?timestamp=${timestamp})`; // Обновляем фоновое изображение
        localStorage.setItem('background', backgroundUrl);
    };
});