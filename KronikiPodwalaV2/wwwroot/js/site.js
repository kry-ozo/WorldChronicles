
const navCheckbox = document.querySelector(".checkbox")
let num = 1

navCheckbox.addEventListener("click", () => {
    num++
    const index = document.querySelector(".index")
    console.log(index)
    if (num % 2 == 0) {
        
        index.style = "z-index: -1"
        index.style= "display: none"
    } else {
        index.style = "display: block; z-index: 1" 
        index.style = "display: block"
    }
})