   M S B A M L   `   `   `  ���� B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfApp1.PagesWpfApp1.Pages      WpfApp1.Pages.Game   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -localclr-namespace:WpfApp1.Pages       N� Title$
  Game�� N� FontSize$ 20(� � 	Resources    ButtonOverlay �� 
TargetType �� Property �� Value �� 
TargetType J� Opacity  
milisecond  	GameField  LightGrayColorBrush  ContainerGameGrid �� RelativeSource	 �� Path
 �� Triggers P� Property P� Value 	 Plate  CornerButton  MainColorBrush��%�  &	        &	 v     &	 �     7  &	     7  &	 P    7  7  �� " �����  � ��
 �   ���  �@J�Opacity$	 0.7Q���  � �� �� " ��.R��� #��z��# z �� .���  � ��$ 20(���  � ��$ Bottom=���  � ��$ 
0, 0, 0, 5q��� " �.���  � ��8   ��  � ��$ -1q��� " �����  � ��$ 20, 0, 0, 0q���  � ��$ 5q���  � �� ��  �� *Self+$	 ActualHeight���  �@��CornerRadius$ 10����  �@J�Opacity$ 1Q���  � ��8   
 P�  � {�$ false��. ���  �@J�Opacity$	 0.6Q���  �@�ForceCursor$
 True����  �@�Cursor$ No���� " �����  � ��
 �   ���  � ��
 �������  � ��
 ���� ��  � ��$ 1q���  � ��$ 10q���  � ��$ 5q���  � ��$ 40(���  � ��8   
 P�  �@J�IsMouseOver$
 True��. ���  � ��
 �������  � ��8  ��  �@�Cursor$
 Hand��.��� .+�� $��30, 40, 30, 30q� � ColumnDefinitions �� $
��241* �$	��300���� $
��559* �.+��� $��0��$��0��.+��� .���� $��Center=�.+���  �� Orientation$ 
Horizontal=�$��25, 0, 0, 0q�$��Center=�.+��� -    ��Name$ minutes��$��40(�$��Bottom=��� $��:��$��40(�$��Bottom=��� -   $ seconds��$��40(�$��Bottom=��� #��[ $��.���� -   $ miliseconds��#��[ �� .+��� -    ��Name$ aa��$��18(�  GrayColorBrush#��[ .��'%найкращий результат�� -    ��Name$ BestTime��$ 
Horizontal=�$��25, 0, 0, 0q�$��Center=�.+��� -   $ MainBestTime��#��[ $��00:00�� �� TextAlignment$ Center=�$��40(�$��Bottom=��� #��[ #��[ $��.���� -   $ BestMilisecond��#��[ #��[ $	��000��$ Center=�$��20(�$��Bottom=��� -    	 
LinkButton#��[	 $��19(�$��0, 10, 0, 0q�.��!таблиця рекордів�� $��0, 40, 0, 0q�.���� .+�� $��0, 10q�.+��� -	    ��Name$ StartBtn�� 
 AccentButton#��[
 $y�Hidden=�.��Почати�� -
   $ PauseBtn��#��[
 .��
Пауза�� -   $ ContinueBtn��#��[
 $y�Hidden=�.��Продовжити�� -   $ 
RestartBtn��  LightButton#��[ $��0, 10q�.��Заново�� -   #��[ $��0, 10, 0, 0q�.��Розмір�� -    ��Name$ GameContainerField��$��1��#��[ ${�False��._�� -    �Name$ 	GameField��#��[ � -   $ OverlayContainer��$y�Hidden=�.+��� -   #��[   � -     �Name$ Overlay��  � NavigationUIVisibility$ Hidden=�  � JournalOwnership$ OwnsJournal=�