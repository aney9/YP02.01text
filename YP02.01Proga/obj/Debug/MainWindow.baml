   M S B A M L   `   `   `  ����G  CYP02.01Proga, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:YP02._01ProgaYP02._01Proga  5   	       YP02._01Proga.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:YP02._01Proga     5   	   _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	     � Title$  
MainWindow��5   	   $	��533��6   $	��650��6)    � 
ResizeMode$ NoResize=�5
   	   ���#000000 � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5       �� 
TargetType   MaterialDesignTextBoxBase �� BasedOn  TextBoxNoUnderline.  (MaterialDesignThemes.Wpf.TextFieldAssist �� Property �� Value��%l   &	       7   �� 5   
   " ��6   8   .�5      ��  �@ UnderlineBrush
 ���� 6N   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      �� 5      $
��0.1* �6   �� 5      �� 5      $
��0.1* �6   	 � RowDefinitions	 5   
   �� 5      $
��0.2* �6   �� 5      $
��0.3* �6   �� 5      $
��0.1* �6   �� 5      $
��0.3* �6   �� 5       $��* �6   �� 5!      $
��0.3* �6   �� 5"      $
��0.1* �6   �� 5#      $
��0.3* �6   �� 5$      $
��0.1* �6   .+�5'   
   �� $��Авторизация��6   $��0��6'   $��3��64   $��1��6H   
�������$��Arial)�6k   $��24(�5(      
 �� TextAlignment$
 Center=�6   $��Center=�6-   $��Center=�6J   �� 5*   
   $��1��6   $��3��5+      $��1��5,       �� CornerRadius$ 25��5-      ���#232323._�5/      �� -   5         ��Name$ login��5/      
�������)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Логин��68   $��20(�6_   $��Arial)�6m   
������ $��0q�6�   $��20,0,0,0q�6�   #��[ 6�   50      �� 52   
   $��1��6   $��3��6!   $��3��65   $ 25��6B   ���#232323._�53      �� -   5        $
 pass��53      
�������$ Пароль��67   $��20(�6_   
������ $��0q�6�   $��20,0,0,0q�6�   #��[ 6�   54      �� 56   
   $��1��6   $��5��6!   $��3��6.   $ 25��6B   ��57      �� 58       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,0&�67   .��59      �  � Color$ #FC4000��6#    � Offset$ 1Q�63   � 5:      $ #7F0DEB��6#   $ 0Q�63   5;      ._�5=      �� -   5        $��Авторизация��5=      
�������
������ $��0q�6W   $��18(�6�   $��Arial)�6�   5>      5@      5A      