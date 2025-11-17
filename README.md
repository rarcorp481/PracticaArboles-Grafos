# # 🌳 Sistema de Gestión Empresarial y Rutas Óptimas

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows%20Forms-User_Interface-blue?style=for-the-badge)
![MaterialSkin](https://img.shields.io/badge/UI-MaterialSkin.2-ff69b4?style=for-the-badge)

> **Caso de Estudio:** Parque Tecnológico "Innovatec" - Universidad Americana (UAM)

Este proyecto es una aplicación de escritorio desarrollada en **C# (Windows Forms)** que implementa estructuras de datos no lineales (**Árboles Generales** y **Grafos**) para resolver problemáticas administrativas y logísticas. La interfaz gráfica ha sido modernizada utilizando la librería **MaterialSkin.2**.

---

## 🚀 Funcionalidades Principales

La aplicación se divide en dos módulos principales según los requerimientos del caso de estudio:

### 🏢 Parte A: Jerarquía Organizativa (Árboles)
Implementación de un **Árbol General** para modelar el organigrama de la empresa.
* **Gestión de Nodos:**
    * Creación de cargos (Raíz e Hijos dinámicos).
    * Eliminación en cascada (Borrado de cargo y subordinados).
    * Renombrado de nodos mediante Input Dialogs personalizados.
* **Búsqueda Avanzada:** Motor de búsqueda **recursivo** que localiza cargos en cualquier nivel de profundidad y resalta la ruta.
* **Recorridos y Visualización:**
    * Pre-orden
    * Post-orden
    * Por Niveles (BFS)
* **Estadísticas en Tiempo Real:**
    * Conteo total de cargos.
    * Cálculo de altura/niveles jerárquicos.
    * Conteo de hojas (cargos sin subordinados).

### 📍 Parte B: Sistema de Rutas (Grafos) *(En desarrollo)*
Modelado de las rutas entre edificios del parque tecnológico.
* **Mapa Interactivo:** Lienzo de dibujo GDI+ para colocar edificios y caminos.
* **Algoritmos:** Cálculo de la ruta más corta (Dijkstra) entre dos puntos.

---

## 🛠️ Tecnologías y Herramientas

* **Lenguaje:** C# (.NET 8.0)
* **Framework:** Windows Forms
* **Diseño UI:** MaterialSkin.2 (Google Material Design wrapper para .NET)
* **IDE:** Visual Studio 2022
* **Control de Versiones:** Git & GitHub

---

## 🧩 Estructura del Código

Para mantener la simplicidad y cumplir con los requisitos académicos, la lógica se ha integrado eficientemente dentro del formulario principal (`FrmPrincipal.cs`), utilizando:

* **Recursividad:** Para las funciones de búsqueda, cálculo de altura y recorridos del árbol.
* **Eventos Dinámicos:** Manejo de interacciones de usuario (Clics, Selección de nodos).
* **GDI+ (Graphics):** Para el dibujado manual de nodos y aristas en el módulo de grafos.
* **Input Dialogs Nativos:** Ventanas emergentes generadas por código para la entrada de datos sin necesidad de formularios externos.

---

## 📦 Instalación y Uso

1.  **Clonar el repositorio:**
    ```bash
    git clone [https://github.com/TU_USUARIO/TU_PROYECTO.git](https://github.com/TU_USUARIO/TU_PROYECTO.git)
    ```
2.  **Abrir la solución:**
    Abre el archivo `.sln` con Visual Studio 2022.
3.  **Restaurar paquetes NuGet:**
    Visual Studio debería descargar automáticamente `MaterialSkin.2`. Si no, ejecuta en la consola del administrador de paquetes:
    ```powershell
    Install-Package MaterialSkin.2
    ```
4.  **Ejecutar:**
    Presiona `F5` o el botón de Iniciar.

---

## ✒️ Autor

**[Rodolfo Alfredo Ramírez Collado]**
* Estudiante de Ingeniería en Sistemas
* Universidad Americana (UAM)
* Managua, Nicaragua

---
*Proyecto realizado para la asignatura de Estructuras de Datos - 2025.*