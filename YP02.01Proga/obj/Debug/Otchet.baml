   M S B A M L   `   `   `  ����G  CYP02.01Proga, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:YP02._01ProgaYP02._01Proga  5   	       YP02._01Proga.Otchet   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:YP02._01Proga     5   	   _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	     � Title$  Otchet��5   	   $	��905��6   $
��1500��6%   ���#000000 � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $��0.01* �6   �� 5      $
��0.7* �6   �� 5      $��0.01* �6   �� 5      $
��0.3* �6   �� 5      $��0.01* �6    � RowDefinitions 5   
   �� 5      �� 5      $
��0.3* �6   �� 5      $
��0.8* �6   �� 5      $
��0.1* �6   �� 5      $
��0.8* �6   �� 5      $��6* �6   �� 5      $
��0.8* �6   �� 5      $
��0.1* �6   �� 5      $
��0.8* �6   �� 5      $
��0.1* �6   �� 5      $
��0.8* �6   �� 5       $
��0.1* �6   �� 5!      $
��0.8* �6   �� 5"      $
��0.3* �6   .+�5%   
   �� $��0��6   $��0��6!   $��6��6.   ��5&      �� 5'       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,0&�67   .��5(      �  � Color$ #FC4000��6#    � Offset$ 0Q�63   � 5)      $ #7F0DEB��6#   $ 1Q�63   5*      5,      �� 5.   
   $9��3Здравствуйте - Руководитель��6   $��1��67   $��0��6G   
�������$��Center=�6g   $��24(�5/      $��Arial)�6"   �� 51   
   -   5        $��3��51      ���#232323$��Center=�66   $��Right=�6Q   $��0q�6m   $��85��6�   $��45��6�    J� Clip 52      �� 53      	 �� RadiusX$	 15Q�6$   
 �� RadiusY$
 15Q�61    �� Rect$ 	0,0,85,45�6>   .��55      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 
ArrowRight=�6&   
�������68   56      &   System.Windows.Controls.DataGrid  58   
   -   5          Name$ dg��58      $��0��6   $��23��6/   $��2��6A   $��1��6U   ���#C4C4C4
���   �   
IsReadOnly .    AutoGenerateColumns .     HorizontalGridLinesBrush
 �   �   VerticalGridLinesBrush
 �   �5;      �� 5@   
   $��3��6   $��2��6!    �� CornerRadius$ 25��6.   ��5A      �� 5B      $	 0,0&�6&   $	 1,0&�67   .��5C      � $ #FC4000��6#   $ 1Q�63   � 5D      $ #7F0DEB��6#   $ 0Q�63   5E      ._�5G      �� -   5        $+��%Сгенерировать отчет��5G      
�������
������ $��0q�6_   $��24(�5H      $��Arial)�6   62   5I      5M      5N      