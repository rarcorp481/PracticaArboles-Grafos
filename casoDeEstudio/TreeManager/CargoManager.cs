using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using casoDeEstudio.PopUpForms;

namespace casoDeEstudio.TreeManager
{
    public static class CargoManager
    {
        /// <summary>
        /// Adds a new cargo node to the specified tree structure, either as the root node or as a child of the selected
        /// node, and updates the provided label with a status message.
        /// </summary>
        /// <remarks>If the tree is empty, the new cargo node is added as the root. If a node is selected,
        /// the new cargo node is added as its child. The label is updated to reflect the result of the
        /// operation.</remarks>
        /// <param name="rootNodes">The collection of root nodes in the tree to which the new cargo node may be added. Must not be null.</param>
        /// <param name="selectedNode">The currently selected node in the tree. If not null and the tree has root nodes, the new cargo node will be
        /// added as a child of this node.</param>
        /// <param name="label">The label control that will be updated to display a status message after the cargo node is added. Must not
        /// be null.</param>
        public static void AddCargo(TreeNodeCollection rootNodes, TreeNode selectedNode, Label label)
        {
            string nombreCargo = PopUpDialog.ShowInputDialog("Ingerese el nombre del nuevo cargo:", "Nuevo nodo");

            if (string.IsNullOrWhiteSpace(nombreCargo)) return;

            if (rootNodes.Count == 0)
            {
                TreeNode raiz = new TreeNode(nombreCargo);
                rootNodes.Add(raiz);
                label.Text = $"Raíz '{nombreCargo}' creada exitosamente";
            }
            else if (selectedNode != null)
            {
                selectedNode.Nodes.Add(nombreCargo);
                selectedNode.Expand();
                label.Text = $"Nodo '{nombreCargo}' agregado exitosamente como hijo de '{selectedNode.Text}'";
            }

        }


        /// <summary>
        /// Removes the selected node and all its subordinate nodes from the specified tree structure, updating the
        /// provided label to reflect the operation.
        /// </summary>
        /// <remarks>A confirmation dialog is displayed before removing the node and its subordinates. If
        /// no nodes exist in the tree or no node is selected, an error message is shown and no action is
        /// taken.</remarks>
        /// <param name="rootNodes">The collection of root nodes in the tree from which the selected node will be removed. Must not be empty.</param>
        /// <param name="selectedNode">The node to remove, along with all its subordinate nodes. If null, no node will be removed and an error
        /// message will be displayed.</param>
        /// <param name="label">The label control to update with a message indicating the result of the removal operation.</param>
        public static void RemoveCargo(TreeNodeCollection rootNodes, TreeNode selectedNode, Label label)
        {
            if (rootNodes.Count == 0) MessageBox.Show("No existen nodos en el Árbol de Jerarquía Empresarial. Primero añade algunos para eliminar", "Error: tvArbol.Nodes.Count == 0", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (selectedNode != null)
            {
                string nombre = selectedNode.Text;
                DialogResult resultado = MessageBox.Show($"¿Estás seguro de querer eliminar el nodo '{nombre}' junto a todos sus subordinados?", "Confirmar elección", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); //added

                if (resultado == DialogResult.Yes)
                {
                    selectedNode.Remove();
                    label.Text = $"El nodo '{nombre}' junto a todos sus subordinados ha sido eliminado exitosamente";
                }
            }
            else
            {
                MessageBox.Show("Selecciona un elemento para borrar", "Error: Nodos Seleccionados == null", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Renames the specified cargo node and updates the provided label to reflect the change.
        /// </summary>
        /// <remarks>If <paramref name="selectedNode"/> is null, an error message is displayed and no
        /// changes are made. The method prompts the user for a new name and updates both the node and the label if a
        /// valid name is provided.</remarks>
        /// <param name="selectedNode">The tree node representing the cargo to be renamed. Must not be null.</param>
        /// <param name="label">The label control that displays the result of the renaming operation. Must not be null.</param>
        public static void RenameCargo(TreeNode selectedNode, Label label)
        {
            if (selectedNode != null)
            {
                string nombreActual = selectedNode.Text;
                string nuevoNombre = PopUpDialog.ShowInputDialog($"El nombre actual del cargo es '{nombreActual}'. Ingrese el nuevo nombre:", "Renombrar nodo");
                if (string.IsNullOrWhiteSpace(nuevoNombre)) return;
                selectedNode.Text = nuevoNombre;
                label.Text = $"El nodo '{nombreActual}' ha sido renombrado a '{nuevoNombre}' exitosamente";
            }
            else
            {
                MessageBox.Show("Selecciona un elemento para renombrar", "Error: Nodos Seleccionados == null", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Prompts the user to search for a cargo node by name and selects it if found.
        /// </summary>
        /// <remarks>
        /// The search is case-insensitive and ignores whitespace. If a match is found, the node is selected 
        /// and brought into view. Displays appropriate messages if the tree is empty or no matches are found.
        /// </remarks>
        /// <param name="treeView">The TreeView control to perform the search on. Must not be null.</param>
        public static void BuscarCargo(TreeView treeView)
        {
            if (treeView.Nodes.Count == 0)
            {
                MessageBox.Show("No existen nodos para buscar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nombre = PopUpDialog.ShowInputDialog("Ingresa el nombre a buscar:", "Buscar nodo");
            if (string.IsNullOrWhiteSpace(nombre)) return;

            string textoBusqueda = nombre.ToLower().Replace(" ", "");
     
            TreeNode nodoEncontrado = BuscarRecursivo(treeView.Nodes, textoBusqueda);
            
            if (nodoEncontrado != null)
            {
                MessageBox.Show($"¡Encontrado! '{nodoEncontrado.Text}'", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

               
                treeView.SelectedNode = nodoEncontrado;
                treeView.Focus();
                nodoEncontrado.EnsureVisible();
            }
            else
            {
                MessageBox.Show("No se encontraron coincidencias.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        // METODO RECURSIVO PRIVADO (SOLO EL BUSCADOR LO USA)
        private static TreeNode BuscarRecursivo(TreeNodeCollection nodos, string busqueda)
        {
            foreach (TreeNode nodo in nodos)
            {
                string textoNodoLimpio = nodo.Text.ToLower().Replace(" ", "");

                // Condición de éxito
                if (textoNodoLimpio.Contains(busqueda)) return nodo;

                // Recursividad
                if (nodo.Nodes.Count > 0)
                {
                    TreeNode encontrado = BuscarRecursivo(nodo.Nodes, busqueda);
                    if (encontrado != null) return encontrado;
                }
            }
            return null;
        }
    }
}
