namespace Tarefa2
{
    internal class Program
    {
        // Estrutura de dados para representar um nó da árvore
        public class TreeNode
        {
            public int Value;
            public TreeNode Left;
            public TreeNode Right;

            public TreeNode(int value)
            {
                Value = value;
            }
        }

        // Método para construir a árvore a partir de um array
        static TreeNode BuildTree(int[] array)
        {
            if (array == null || array.Length == 0) return null;

            int maxValue = array.Max();
            int maxIndex = Array.IndexOf(array, maxValue);

            // Inicializa o nó raiz com o maior valor do array
            var root = new TreeNode(maxValue);

            // Seleciona todos os elementos ao lado esquerdo do maior valor no array e os insere nos nós à esquerda
            var leftPart = array.Take(maxIndex).OrderByDescending(x => x).ToArray();
            root.Left = BuildBranch(leftPart);

            // Seleciona todos os elementos ao lado direito do maior valor no array e os insere nos nós à direita
            var rightPart = array.Skip(maxIndex + 1).OrderByDescending(x => x).ToArray();
            root.Right = BuildBranch(rightPart);

            return root;
        }

        // Método auxiliar para construir uma subárvore, ou galho (branch), a partir de um array
        static TreeNode BuildBranch(int[] values)
        {
            // Se o array estiver vazio, retorna null
            if (values.Length == 0) return null;

            TreeNode root = new TreeNode(values[0]);
            TreeNode current = root;

            // Cria os nós à direita do nó raiz da subárvore
            for (int i = 1; i < values.Length; i++)
            {
                current.Right = new TreeNode(values[i]);
                current = current.Right;
            }

            return root;
        }

        static void PrintTree(TreeNode root)
        {
            // Inicializa a função recursiva para imprimir a árvore em formato ASCII
            PrintAsciiTree(root, "", true);
        }

        static void PrintAsciiTree(TreeNode node, string indent, bool isLast)
        {
            if (node == null) return;

            // Imprime o valor do nó atual com a indentação apropriada
            Console.Write(indent);
            Console.Write(isLast ? "└── " : "├── ");
            Console.WriteLine(node.Value);

            // Atualiza a indentação para os próximos nós
            indent += isLast ? "    " : "│   ";

            // Verifica se o nó atual tem filhos à esquerda e à direita,
            // caso contrário, encerra a chamada recursiva
            bool hasLeft = node.Left != null;
            bool hasRight = node.Right != null;

            // Recursivamente imprime os nós à esquerda
            if (hasLeft)
                PrintAsciiTree(node.Left, indent, !hasRight);

            // Recursivamente imprime os nós à direita
            if (hasRight)
                PrintAsciiTree(node.Right, indent, true);
        }

        static void Main(string[] args)
        {
            // Inicializa os dois cenários de teste
            int[] array1 = { 3, 2, 1, 6, 0, 5 };
            int[] array2 = { 7, 5, 13, 9, 1, 6, 4 };

            Console.WriteLine("Cenário 1:");
            var root1 = BuildTree(array1);
            PrintTree(root1);

            Console.WriteLine("\nCenário 2:");
            var root2 = BuildTree(array2);
            PrintTree(root2);
        }
    }
}
