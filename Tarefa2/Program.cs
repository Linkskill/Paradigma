namespace Tarefa2
{
    internal class Program
    {
        // Estrutura de dados para representar um nó da árvore
        public class TreeNode
        {
            public int Value { get; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }

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
            root.Left = BuildBranch(leftPart, true);

            // Seleciona todos os elementos ao lado direito do maior valor no array e os insere nos nós à direita
            var rightPart = array.Skip(maxIndex + 1).OrderByDescending(x => x).ToArray();
            root.Right = BuildBranch(rightPart, false);

            return root;
        }

        // Método auxiliar para construir uma subárvore, ou galho (branch), a partir de um array
        static TreeNode BuildBranch(int[] values, bool isLeft)
        {
            // Se o array estiver vazio, retorna null
            if (values.Length == 0) return null;

            TreeNode root = new TreeNode(values[0]);
            TreeNode current = root;

            if (isLeft)
            {
                // Cria os nós à esquerda do nó raiz da subárvore
                for (int i = 1; i < values.Length; i++)
                {
                    current.Left = new TreeNode(values[i]);
                    current = current.Left;
                }
            }
            else
            {
                // Cria os nós à direita do nó raiz da subárvore
                for (int i = 1; i < values.Length; i++)
                {
                    current.Right = new TreeNode(values[i]);
                    current = current.Right;
                }
            }

            return root;
        }
        
        static void PrintAsciiTree(TreeNode node)
        {
            if (node == null) return;

            TreeNode leftBranch = node.Left;
            TreeNode rightBranch = node.Right;
            string indent = "    ";

            // Imprime o nó raiz da árvore
            Console.WriteLine(indent + " " + node.Value);
            Console.WriteLine(indent + " │");

            // Imprime os ramos esquerdo e direito da árvore
            while (leftBranch != null || rightBranch != null)
            {
                if (leftBranch != null)
                {
                    Console.Write(leftBranch.Value);
                    Console.Write("──┘");
                    leftBranch = leftBranch.Left;
                }
                else
                {
                    Console.Write(indent);
                }

                Console.Write(indent);

                if (rightBranch != null)
                {
                    Console.Write("└──");
                    Console.Write(rightBranch.Value);
                    rightBranch = rightBranch.Right;
                }
                Console.WriteLine("");
            }
        }

        static void Main(string[] args)
        {
            // Inicializa os dois cenários de teste
            int[] array1 = { 3, 2, 1, 6, 0, 5 };
            int[] array2 = { 7, 5, 13, 9, 1, 6, 4 };

            Console.WriteLine("Cenário 1:");
            var root1 = BuildTree(array1);
            PrintAsciiTree(root1);

            Console.WriteLine("\nCenário 2:");
            var root2 = BuildTree(array2);
            PrintAsciiTree(root2);
        }
    }
}
