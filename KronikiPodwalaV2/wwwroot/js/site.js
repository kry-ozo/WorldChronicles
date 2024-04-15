try {
    document.querySelector("#admin-options").addEventListener("click", () => {
        console.log("CLICK")
        const adminNav = document.querySelector(".admin-nav");
        adminNav.classList.toggle("active");
    });
} catch (e) {

}

try {
    document.querySelector("#filters").addEventListener("click", () => {
        const filters = document.querySelector(".search-nav");
        filters.classList.toggle("active");
    });
} catch (e) {
    
}

try {
    document.querySelector('#textArea').addEventListener('input', function () {
    this.style.height = 'auto'; // Ustaw wysokość na auto, aby uwzględnić całą zawartość
    this.style.height = (this.scrollHeight) + 'px'; // Ustaw wysokość na wysokość zawartości
});
} catch (e) {

}