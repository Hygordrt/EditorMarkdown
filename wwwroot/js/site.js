// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const points = document.querySelectorAll('.point');
const sections = document.querySelectorAll('.section');

let highlightedIndex = 0;

function updateHighlighted() {
    points.forEach((point, index) => {
        if (index === highlightedIndex) {
            point.classList.add('highlighted');
        } else {
            point.classList.remove('highlighted');
        }
    });
}

window.addEventListener('scroll', () => {
    const scrollY = window.scrollY;

    sections.forEach((section, index) => {
        const sectionTop = section.offsetTop;
        const sectionHeight = section.offsetHeight;

        if (scrollY >= sectionTop && scrollY < sectionTop + sectionHeight) {
            highlightedIndex = index;
            updateHighlighted();
        }
    });
});