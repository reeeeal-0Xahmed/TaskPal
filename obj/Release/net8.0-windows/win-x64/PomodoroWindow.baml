   M S B A M L   `   `   `  ���� B  >TaskPal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TaskPalTaskPal      TaskPal.PomodoroWindow   localclr-namespace:TaskPal  W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  PomodoroTimer��$	��300��$	��400�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�����  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,1&�.���  � Color$ 	#FF00BFFF�� � Offset$ 0Q�� $ 	#FF1E90FF��$ 1Q� � 	Resources    ButtonStyle �� 
TargetType	 �� Property
 �� Value��%�   &	        �� " ��.��� 	 � ��

 ��ح��� 	 � ��

 �   ��� 	 � ��$
 14(��� 	 � ��$
 10q��� 	 � ��$
 5q�.��� ���� $ 0.5,1&�$ 0.5,0&�.��� $ 	#FF8AC0DE��� $ 	#FFB0A0DD��$ 1Q� � RowDefinitions �� �� $
��Auto �$��0��.+��� $��Center=�$��Center=�$	��146��$	��236��.+�� $	��236��$	��151��.+��� -    ��Name$ 	timerText��$	��157��$��52��$
��Left=�$	��Top=�$��40(�$
��Bold"�$��25:00��$��Digital-7 Italic)� �� TextAlignment$ Center=�$��	61,52,0,0q��� $��/Background.png��$
��Fill=� J� RenderTransformOrigin$ 0.735,-0.168&�$��
69,6,77,27q��� -    ��Name$ BreakTypeComboBox��$
��Left=�$	��Top=�$	��120��$��190,229,0,0q�$��22��.@��� $��Short Break (5 min)���� $��Long Break (15 min)���� -   $ PomodoroCounter��$��Pomodoros Completed: 0��$
��Left=�$	��Top=�$��4,17,0,0q�$��14(�$��Franklin Gothic Demi)�$��19��$	��162��
��������� -    ��Name$ startButton��$��Let's focus!!!!��$��11(�$��Yu Gothic UI Semibold)�$��Center=�$��69,218,230,11q�
���   �����  �� Color$ White�� �� Opacity$	 0.5Q����� " ��.��� 	 � ��

 ������ 	 � ��

 �   ��� 	 � ��$
 1q��� 	 � ��

 ������� 	 � ��$

 Bold"��� 	 �@�Cursor$

 Hand�� �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ��� 	 � ��

 ��·��� 	 � ��

 ��� �P�  � ��$
 True��. ��� 	 � ��

 ���F�����  �� 
TargetType" ��.R��� #��z��#��z��#��z�� �� CornerRadius$ 15��._��� $��Center=�$��Center=��� -   $��	Main Menu��$��0,21,25,205q�$��11(�$��Yu Gothic UI Semibold)�$��Right=�$	��100��$ 0.5,0.5&����� $ White��$	 0.5Q����� " ��.��� 	 � ��

 ������ 	 � ��

 �   ��� 	 � ��$
 1q� P�  �@J�IsMouseOver$
 True��. ��� 	 � ��

 ��·��� 	 � ��

 ��� �P�  � ��$
 True��. ��� 	 � ��

 ���F����� " ��.R��� #��z��#��z��#��z��$ 15��._��� $��Center=�$��Center=��� $'��!What kind of break do you want?
��$
��Left=�$��186,208,0,0q�$	��Top=�$��32��$��8(�$��Franklin Gothic Demi)�
�������