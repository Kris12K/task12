using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task12__12_5_
{
    public class BinaryTree<T>
     where T : IComparable
    {
        public BinaryTreeNode<T> head;
        private int count;

        public int Count {get { return count; } }

        //добавление элемента
        public void Add(T value, ref int movements, ref int comparisons)
        {
            //если  дерево пустое,то создать корневой узел
            if (head == null)
            {
                comparisons++;
                head = new BinaryTreeNode<T>(value);
            }
            //иначе найти место для вставки
            else
                AddTo(head, value, ref  movements, ref comparisons);

            count++;
        }

        //вставка элемента
        private void AddTo(BinaryTreeNode<T> node, T value, ref int movements, ref int comparisons)
        {
            //если вставляемое значение меньше узла
            if (value.CompareTo(node.Value) < 0)
            {
                comparisons++;
                //если нет левого поддерева, то добавляем
                if (node.Left == null)
                {
                    comparisons++;
                    node.Left = new BinaryTreeNode<T>(value);
                }
                else
                {
                    //иначе идем дальше
                    AddTo(node.Left, value, ref  movements, ref comparisons);
                }
            }
            //иначе -вставляемое значение больше или равно узлу
            else
            {
                //если нет правого поддерева, то добавляем
                if (node.Right == null)
                {
                    comparisons++;
                    node.Right = new BinaryTreeNode<T>(value);
                }
                else
                {
                    //иначе идем дальше
                    AddTo(node.Right, value, ref movements, ref  comparisons);
                }
            }
        }
        
        //дерево в отсортированный массив
        public static void SortedTreeInArray(BinaryTreeNode<T> p,ref T[]array,ref int count)
        {
            if (p != null&&array!=null)//check aray length
            {
                SortedTreeInArray(p.Left,ref array,ref count);//переход к левому поддереву
                array[count] = p.Value;
                count++;
                SortedTreeInArray(p.Right,ref array,ref count);//переход к правому поддереву
            }
        }
        
    }
}
