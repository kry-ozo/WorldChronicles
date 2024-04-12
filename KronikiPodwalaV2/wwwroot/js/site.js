try {
    document.querySelector("#filters").addEventListener("click", () => {
        const filters = document.querySelector(".search-nav");
        filters.classList.toggle("active");
    });
} catch (e) {
    
}
