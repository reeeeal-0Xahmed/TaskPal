   M S B A M L   `   `   `  ����   TaskPal    TaskPal.TasksWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Tasks��$	��560��$	��874�� � 
ResizeMode$ CanMinimize=����#f4f4f4.��� ����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF8AC0DE��� $ 	#FFB0A0DD�� � Offset$ 1Q� � RowDefinitions �� $
��Auto ��� $��* �.+���  �� Orientation$ 
Horizontal=�$��Center=�$��	0,10,0,10q�$��0��$	��774�� � 	Resources 	 �� 
TargetType
 �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property P� Value��%  '��       �� "	 ��.��� 
 � ��
 ������ 
 � ��
 ������� 
 � ��$
 Bold"��� 
 � ��
 �   ��� 
 � ��$ 1q��� 
 � ��$
 10,5q��� 
 � ��$	 120���� 
 � ��$ 5q��� 
 � ��$ 40���� 
 � ��$ Center=��� 
 � ��$ Center=��� 
 � �� �� " ��.R�� .+��� #��z��#��z��#��z��$ 10��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ��� 
 � ��
 ��·��� 
 �@�Cursor$
 Hand��P�  � ��$
 True��. ��� 
 � ��
 ��·�.+��� -   $��	Add Group������  �� Color$ White�� �� Opacity$	 0.5Q��� -   $��Add Task������ $ White��$	 0.5Q��� -   $��Edit Group Name������ $ White��$	 0.5Q��� -   $��Delete Task������ $ White��$	 0.5Q��� -   $��Delete Group������ $ White��$	 0.5Q��� -   $��	Main Menu��$	��115������ $ White��$	 0.5Q��� -    ��Name$ GroupListBox��$��1��$��555,40,18,120q� �� DisplayMemberPath$
 Name������ $ Black��$	 0.3Q����� " ��.R��� #��z��
�������$��1q�$ 15��._��� .���� �� -   $ TaskListBox��$��1��$��230,41,343,120q����� $ Black��$	 0.3Q����� " ��.R��� #��z��
�������$��1q�$ 15��._��� .���� ���� .R��� $ 
Horizontal=�.+��� $��Center=�$��5q� d� 	IsChecked �� *IsCompleted+�� $
��Bold"�$��5q����� *Name+�� $	�� - ��
��������� ���� *
Priority+���� "	 ��.��� 
 � ��
 ����� �� Triggers ��  �� Binding �� *
Priority+ �� Value Low.a��� 
 � ��
 ������  �� *
Priority+
 Medium.a��� 
 � ��
 � �����  �� *
Priority+ High.a��� 
 � ��
 �\\���� $��1��$ Vertical=�$
��Left=�$��5,13,0,0q� J� RenderTransformOrigin$ 	0.5,0.539&�.+��� $��Edit Task Name :��$��Yu Gothic UI Semibold)��� -	    ��Name$ TaskNameTextBox��$	��200��$��5q��� $��Edit Task Priority:��$��Yu Gothic UI Semibold)��� -
    ��Name$ TaskPriorityComboBox��$	��200��$��26������ $	 0,1&�$	 0.5Q�.��� $ 	#FFF0F0F0��� $ 	#FFE5E5E5��$ 1Q�.@��� $	��Low���� $��Medium���� $
��High���� -   $
��Save��$	��100��$��24���� $��Tasks��$
��Left=�$��	230,4,0,0q�$��1��$	��Top=�$��20(�$��Yu Gothic UI Semibold)�$ 0.161,0.684&��� $��Groups��$
��Left=�$��	555,4,0,0q�$��1��$	��Top=�$��84��$��20(�$��Yu Gothic UI Semibold)�