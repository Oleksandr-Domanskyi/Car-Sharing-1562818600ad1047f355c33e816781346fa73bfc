document.addEventListener("DOMContentLoaded", function () {
    const backgroundUrl = 'https://img5.goodfon.ru/wallpaper/nbig/0/44/lamborghini-fon-mashina.jpg';
    const timestamp = new Date().getTime(); // �������� ������� ����� � �������������
    const img = new Image();
    img.src = `${backgroundUrl}?timestamp=${timestamp}`; // ��������� ��������� �������� � URL
    img.onload = function () {
        document.body.style.backgroundImage = `url(${backgroundUrl}?timestamp=${timestamp})`; // ��������� ������� �����������
        localStorage.setItem('background', backgroundUrl);
    };
});