using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour
{
	public Text text;
	private enum States {
		cell,
		cell_mirror,
		cell_open,
		mirror_0,
		mirror_1,
		sheets_0, 
		sheets_1,
		lock_0,
		lock_1,
		corridor_0,
		corridor_1,
		corridor_2,
		corridor_3,
		stairs_0,
		stairs_1,
		stairs_2,
		toilet_0,
		toilet_1,
		toilet_2,
		floor_0,
		freedom
		};
	private States myState;

	// Use this for initialization
	void Start ()
	{
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update ()
	{
		print (myState);
		if 		(myState == States.cell)			{cell();}
		else if (myState == States.cell_mirror)		{cell_mirror();}
		else if (myState == States.sheets_0)		{sheets_0();}
		else if (myState == States.sheets_1)		{sheets_1();}
		else if (myState == States.lock_0)			{lock_0();}
		else if (myState == States.lock_1)			{lock_1();}
		else if (myState == States.mirror_0)		{mirror_0();}
		else if (myState == States.mirror_1)		{mirror_1();}
		else if (myState == States.corridor_0)		{corridor_0();}
		else if (myState == States.corridor_1)		{corridor_1();}
		else if (myState == States.corridor_2)		{corridor_2();}
		else if (myState == States.corridor_3)		{corridor_3();}
		else if (myState == States.stairs_0)		{stairs_0();}
		else if (myState == States.stairs_1)		{stairs_1();}
		else if (myState == States.stairs_2)		{stairs_2();}
		else if (myState == States.toilet_0)		{toilet_0();}
		else if (myState == States.toilet_1)		{toilet_1();}
		else if (myState == States.toilet_2)		{toilet_2();}
		else if (myState == States.floor_0)			{floor_0();}
		else if (myState == States.freedom)			{freedom();}
	}
	
	#region State methods
	
	//---------cell----------
	
	void cell ()
	{
		text.text = "Маленькая камера, дверь, зеркало на стене и кушетка " +
					"с кучей грязных тряпок на ней, заменящих простынь. " +
					"Ты не понимаешь, где ты и как сюда попал.\n\n" +
					"L - осмотреть дверь, M - осмотреть зеркало, " +
					"S - осмотреть кровать.";
		if 		(Input.GetKeyDown (KeyCode.S))		{myState = States.sheets_0;}
		else if (Input.GetKeyDown (KeyCode.L))		{myState = States.lock_0;}
		else if (Input.GetKeyDown (KeyCode.M))		{myState = States.mirror_0;}
	}
	
	void cell_mirror () //зеркало в руках
	{
		text.text = "Ты все еще стоишь посреди камеры, держа в руке кусок разбитого зеркала. " + 
					"Тебе надо придумать, как открыть кодовый замок.\n\n" +
					"L - осмотреть дверь, M - осмотреть зеркало, " +
					"S - осмотреть кровать.";
		if 		(Input.GetKeyDown (KeyCode.S))		{myState = States.sheets_1;}
		else if (Input.GetKeyDown (KeyCode.L))		{myState = States.lock_1;}
		else if (Input.GetKeyDown (KeyCode.M))		{myState = States.mirror_1;}
	}
	
	void cell_open () //дверь открыта
	{
		text.text = "Все та же маленькая камера с грязной кроватью.\n\n" +
					"C - выйти в коридор.";
		if 		(Input.GetKeyDown (KeyCode.C))	{
			if 		(myState == States.corridor_0)	{myState = States.corridor_0;}
			else if (myState == States.corridor_1)	{myState = States.corridor_1;}
			else if (myState == States.corridor_2)	{myState = States.corridor_2;}
			}
	}
	
	//----------sheets----------
	
	void sheets_0 ()
	{
		text.text = "Кажется эти простыни пора было поменять несколько месяцев назад. " +
					"Невозможно поверить, что кто-то станет их использовать.\n\n" +
					"R - назад.";
		if 		(Input.GetKeyDown (KeyCode.R))		{myState = States.cell;}
	}
	
	void sheets_1 () //зеркало в руках
	{
		text.text = "Осколок зеркала в твоей руке не делает эти тряпки хоть немного привлекательнее.\n\n" +
					"R - назад.";
		if 		(Input.GetKeyDown (KeyCode.R))		{myState = States.cell_mirror;}
	}
	
	//----------lock----------
	
	void lock_0 ()
	{
		text.text = "Это старый кодовый замок. У тебя нет идей, какую именно комбинацию " +
					"необходимо ввести, чтобы его открыть. Возможно, как-то можно разглядеть " +
					"кнопки снаружи, может быть на них остались следы.\n\n" +
					"R - назад.";
		if 		(Input.GetKeyDown (KeyCode.R))		{myState = States.cell;}
	}
	
	void lock_1 () //зеркало в руках
	{
		text.text = "Ты аккуратно просовываешь осколок зеркала через решетку, так чтобы было видно замок. " +
					"Ты видишь,что некоторые из кнопок темнее, чем другие из-за грязных пальцев, " +
					"которыми их нажимали. Ты нажимаешь эти кнопки, и слушишь щелчок.\n\n" +
					"O - открыть дверь, R - назад.";
		if 		(Input.GetKeyDown (KeyCode.R))		{myState = States.cell_mirror;}
		else if (Input.GetKeyDown (KeyCode.O))		{myState = States.corridor_0;}	
	}
	
	//----------mirror----------
	
	void mirror_0 ()
	{
		text.text = "Старое, грязное, разбитое зеркало, в котором можно разглядеть отражение. " +
					"Под ногами ты замечаешь несколько осколков от этого зеркала.\n\n" +
					"T - взять осколок, R - назад.";
		if 		(Input.GetKeyDown (KeyCode.R))		{myState = States.cell;}
		else if (Input.GetKeyDown (KeyCode.T))		{myState = States.cell_mirror;}
	}
	
	void mirror_1 () //зеркало в руках
	{
		text.text = "Все то же грязное, разбитое зеркало, в котором можно разглядеть отражение.\n\n" +
					"R - назад.";
		if 		(Input.GetKeyDown (KeyCode.R))		{myState = States.cell_mirror;}
	}
	
	//----------corridor----------
	
	void corridor_0 ()
	{
		text.text = "Ты находишься в тюремном коридоре. Перед тобой дверь в туалет и лестница, ведущая наверх.\n\n" +
					"C - вернуться в камеру, S - осмотреть лестницу, T - осмотреть дверь в туалет, F - осмотреть пол.";
		if 		(Input.GetKeyDown (KeyCode.C))		{myState = States.cell_open;}
		else if (Input.GetKeyDown (KeyCode.S))		{myState = States.stairs_0;}
		else if (Input.GetKeyDown (KeyCode.T))		{myState = States.toilet_0;}
		else if (Input.GetKeyDown (KeyCode.F))		{myState = States.floor_0;}
	}
	
	void corridor_1 () //заколка в руках
	{
		text.text = "Ты находишься в тюремном коридоре. Перед тобой дверь в туалет и лестница, ведущая наверх.\n\n" +
					"C - вернуться в камеру, S - осмотреть лестницу, T - осмотреть дверь в туалет.";
		if 		(Input.GetKeyDown (KeyCode.C))		{myState = States.cell_open;}
		else if (Input.GetKeyDown (KeyCode.S))		{myState = States.stairs_1;}
		else if (Input.GetKeyDown (KeyCode.T))		{myState = States.toilet_1;}
	}
	
	void corridor_2 () //туалет открыт
	{
		text.text = "Ты находишься в тюремном коридоре. Перед тобой дверь в туалет и лестница, ведущая наверх. " +
					"Дверь в туалет открыта.\n\n" +
					"C - вернуться в камеру, S - осмотреть лестницу, T - зайти в туалет.";
		if 		(Input.GetKeyDown (KeyCode.C))		{myState = States.cell_open;}
		else if (Input.GetKeyDown (KeyCode.S))		{myState = States.stairs_1;}
		else if (Input.GetKeyDown (KeyCode.T))		{myState = States.toilet_2;}
	}
	
	void corridor_3 () //ты переоделся в уборщика
	{
		text.text = "Ты находишься в тюремном коридоре, одетый в форму уборщика. Перед тобой дверь в туалет и лестница, ведущая наверх.\n\n" +
				"C - вернуться в камеру, S - осмотреть лестницу, T - осмотреть дверь в туалет.";
		if 		(Input.GetKeyDown (KeyCode.C))		{myState = States.cell_open;}
		else if (Input.GetKeyDown (KeyCode.S))		{myState = States.stairs_2;}
	}
	
	//----------stairs----------
	
	void stairs_0 ()
	{
		text.text = "Сверху слышны разговоры охранников. Пожалуй, не стоит туда идти.\n\n" +
					"R - назад.";
		if 		(Input.GetKeyDown (KeyCode.R))		{myState = States.corridor_0;}
	}
	
	void stairs_1 () //заколка в руках
	{
		text.text = "Вряд ли с помощью заколки удастся обезвредить охранников.\n\n" +
					"R - назад.";
		if 		(Input.GetKeyDown (KeyCode.R))		{myState = States.corridor_1;}
	}
	
	void stairs_2 () //заколка в руках
	{
		text.text = "Если ты будешь вести себя спокойно, то охранники посчитают тебя обычным уборщиком. " +
					"Стоит попробовать!\n\n" +
					"U - подняться по лестнице, R - назад.";
		if 		(Input.GetKeyDown (KeyCode.R))		{myState = States.corridor_3;}
		else if (Input.GetKeyDown (KeyCode.U))		{myState = States.freedom;}
	}
	
	//----------floor----------
	
	void floor_0 () //заколка в руках
	{
		text.text = "Пол выглядит недавно помытым, но это не делает его чистым. " +
					"У стены ты замечаешь шпильку для волос.\n\n" +
					"T - поднять шпильку, R - назад.";
		if 		(Input.GetKeyDown (KeyCode.T))		{myState = States.corridor_1;}
		else if (Input.GetKeyDown (KeyCode.R))		{myState = States.corridor_0;}
	}
	
	//----------toilet----------
	
	void toilet_0 ()
	{
		text.text = "Дверь закрыта. Внутри тихо.\n\n" +
					"R - назад.";
		if 		(Input.GetKeyDown (KeyCode.R))		{myState = States.corridor_0;}
	}
	
	void toilet_1 () //шпилька в руках
	{
		text.text = "Дверь закрыта. Внутри тихо. Может быть получится вскрыть замок шпилькой.\n\n" +
					"O - вскрыть замок, R - назад.";
		if 		(Input.GetKeyDown (KeyCode.R))		{myState = States.corridor_1;}
		else if (Input.GetKeyDown (KeyCode.O))		{myState = States.corridor_2;}
	}
	
	void toilet_2 () //шпилька в руках
	{
		text.text = "Грязный, обшарпаный туалет. В углу стоит швабра и висит форма уборщика. Выглядит почище, чем твои обноски.\n\n" +
					"D - надеть форму, R - назад.";
		if 		(Input.GetKeyDown (KeyCode.R))		{myState = States.corridor_2;}
		else if (Input.GetKeyDown (KeyCode.D))		{myState = States.corridor_3;}
	}
	
	//----------freedom----------
	
	void freedom ()
	{
		text.text = "Ты проходишь мимо охранников с каменным лицом и выходишь в дверь напротив. Ура, поздравляю! Ты на свободе!\n\n" +
					"G - сыграть еще раз.";
		if 		(Input.GetKeyDown (KeyCode.G))		{myState = States.cell;}
	}
	#endregion
}
