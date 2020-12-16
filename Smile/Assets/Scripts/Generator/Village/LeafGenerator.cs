using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafGenerator : MonoBehaviour
{
}

public class Leaf
{

	private const int MIN_LEAF_SIZE = 6;

	public int y;// положение и размер этого листа
    public int x;
    public int width;
    public int height;
	public Leaf leftChild; // левый дочерний Leaf нашего листа
	public Leaf rightChild; // правый дочерний Leaf нашего листа
	//public var room:Rectangle; // комната, находящаяся внутри листа
	//public var halls:Vector.; // коридоры, соединяющие этот лист с другими листьями

	public function Leaf(int X, int Y, int Width, int Height)
	{
		// инициализация листа
		x = X;
		y = Y;
		width = Width;
		height = Height;
	}

	public function split():Boolean
	{
		// начинаем разрезать лист на два дочерних листа
		if (leftChild != null || rightChild != null)
			return false; // мы уже его разрезали! прекращаем!

		// определяем направление разрезания
		// если ширина более чем на 25% больше высоты, то разрезаем вертикально
		// если высота более чем на 25% больше ширины, то разрезаем горизонтально
		// иначе выбираем направление разрезания случайным образом
		bool splitH = true;
		if (width > height && width / height >= 1.25)
			splitH = false;
        // TODO
		int max = (splitH ? height : width) - MIN_LEAF_SIZE; // определяем максимальную высоту или ширину
		if (max <= MIN_LEAF_SIZE)
			return false; // область слишком мала, больше её делить нельзя...

		int split = Registry.randomNumber(MIN_LEAF_SIZE, max); // определяемся, где будем разрезать

		// создаём левый и правый дочерние листы на основании направления разрезания
		if (splitH)
		{
			leftChild = new Leaf(x, y, width, split);
			rightChild = new Leaf(x, y + split, width, height - split);
		}
		else
		{
			leftChild = new Leaf(x, y, split, height);
			rightChild = new Leaf(x + split, y, width - split, height);
		}
		return true; // разрезание выполнено!
	}
}
