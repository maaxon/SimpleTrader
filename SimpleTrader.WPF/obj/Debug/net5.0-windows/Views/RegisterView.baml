   M S B A M L   `   `   `  ����K  GSimpleTrader.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:SimpleTrader.WPF.ViewsSimpleTrader.WPF.Views  5      J FPasswordBoxMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null`Aclr-namespace:PasswordBoxMVVM.Components;assembly=PasswordBoxMVVMPasswordBoxMVVM.Components 5   L   )    #SimpleTrader.WPF.Views.RegisterView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:SimpleTrader.WPF.Views     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      X
componentsAclr-namespace:PasswordBoxMVVM.Components;assembly=PasswordBoxMVVM     6L   $��24(�5
        � 	Resources  5          BooleanToVisibilityConverter��%   &	        �� 5   
   6'   5      ��5      �� 5   
    �� ImageSource$% /Resources/login-background.jpg��5       �� Opacity$	 0.5Q�5       j� Stretch$ UniformToFill=�5      .��5      �� $��25q�6    �� Padding$ 50q�6   $��Center=�5   	   $��Center=�5   	   
�������  BrushPrimary2#��[ 5   	   $��3q�5   	    �� CornerRadius$ 10��5   	    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 10Q�6      Color$
 Gray��6/   ._�5   
   � 	 � IsSharedSizeScope$
	 True��6   
 � RowDefinitions
 5       �� 5!      $
��auto �6    �� 5"      $
��auto �6    �� 5#      $
��auto �6    .+�5&      �� $��0��6   $��Center=�5'      $��48(�5(      $��Simple Trader��5)      �� 5+      $��1��6   $
��0,10q�6%   $��Center=�5,      $��18(�5-      $
��Thin"�5.      $5��/The world's simplest stock trading application.��5/      � 51      $��2��6   $
��0,20q�6    
 52      �� 53      $
��auto �6$   �� 54      $
��auto �6$   �� 55      $
��auto �6$   �� 56      $
��auto �6$   �� 57      $
��auto �6$   �� 58      $
��auto �6$   �� 59      $
��auto �6$   .+�5<      � $��0��6   $
��0,10q�6$    � ColumnDefinitions 5=      �� 5>      $
��auto �6+    z� SharedSizeGroup$ Label��68   �� 5?      $	��300 �6+   .+�5B      �� $��0��6    $��Email��60   �� 5C      $��1��6   $��20,0,0,0q�6.   ��5D      �� *Email+ �� UpdateSourceTrigger$ PropertyChanged=�5E      � 5G      $��1��6   $
��0,10q�6$    5H      �� 5I      $
��auto �6+   $ Label��68   �� 5J      $	��300 �6+   .+�5M      �� $��0��6    $��Username��60   �� 5N      $��1��6   $��20,0,0,0q�6.   ��5O      �� *
Username+$ PropertyChanged=�5P      � 5R      $��2��6   $
��0,10q�6$    5S      �� 5T      $
��auto �6+   $ Label��68   �� 5U      $	��300 �6+   .+�5X      �� $��0��6    $��Password��60   4  .PasswordBoxMVVM.Components.BindablePasswordBox  5Y      $��1��65   $��20,0,0,0q�6E      Password 5Z      �� *
Password+5[      � 5]      $��3��6   $
��0,10q�6$    5^      �� 5_      $
��auto �6+   $ Label��68   �� 5`      $	��300 �6+   .+�5c      �� $��0��6    $��Confirm Password��60     5d      $��1��65   $��20,0,0,0q�6E    5e      �� *ConfirmPassword+5f      �� 5h      $��4��6   $
��0,10q�6&   $��Center=�5i      $��Register��5k       �� 	IsDefault$
 True��5l      ��5j      �� *RegisterCommand+5l      �� 5n      $��5��6   $��0,10,0,0q�6&   $��Center=�5o      
������ $��Already have an account?��5r      $��14(�5s      
����  ���5q      �� *ViewLoginCommand+5t      �� 5v      $��6��6   $��0,10,0,0q�6)   $��Center=�5w      
���  �� � DataContext 5x      �� *ErrorMessageViewModel+��5z      �� *	Message+y�5{      �� *
HasMessage+ �� 	Converter# [  5|      5}      5~      5      