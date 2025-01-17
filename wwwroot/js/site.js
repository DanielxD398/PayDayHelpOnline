// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener('DOMContentLoaded', () => {
    // Escuchar eventos de click de manera delegada
    document.addEventListener('click', function (e) {
        const target = e.target;

        // Verificar si el elemento clickeado es un enlace relevante
        if (target.classList.contains('nav-link') || target.classList.contains('text-dark') || target.classList.contains('btn-link')) {
            e.preventDefault();
            const path = target.dataset.topic; // Obtener el path desde el atributo data-topic
            if (path) {
                console.log(`Cargando vista: ${path}`);
                loadView(path, true); // Llamar la función para cargar la vista y actualizar el historial
            }
        }
    });

    // Función para cargar la vista dinámicamente
    function loadView(path, addToHistory = false) {
        fetch(`/PayDay/Index?path=${path}`) // Usar la acción Index del controlador
            .then(response => {
                if (response.ok) {
                    return response.text(); // Obtener el HTML de la vista
                }
                throw new Error('Vista no encontrada'); // Manejo de errores si la vista no existe
            })
            .then(html => {
                // Reemplazar el contenido en el contenedor principal
                document.querySelector('main[role="main"].pb-3').innerHTML = html;

                // Agregar al historial si se especifica
                if (addToHistory) {
                    history.pushState({ path: path }, '', `?path=${path}`);
                }
            })
            .catch(error => console.error('Error loading view:', error));
    }

    // Escuchar los cambios en el historial para permitir la navegación con el botón "Atrás"
    window.addEventListener('popstate', (event) => {
        if (event.state && event.state.path) {
            console.log(`Navegando al historial: ${event.state.path}`);
            loadView(event.state.path, false); // Cargar la vista correspondiente al estado del historial sin agregar al historial
        }
    });

    // Al cargar la página, verificar si hay un parámetro "path" en la URL
    const urlParams = new URLSearchParams(window.location.search);
    const initialPath = urlParams.get('path');

    if (initialPath) {
        console.log(`Cargando vista inicial: ${initialPath}`);
        loadView(initialPath, false); // Cargar la vista inicial sin agregar al historial
    }
});



