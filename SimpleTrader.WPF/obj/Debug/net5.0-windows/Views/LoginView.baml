   M S B A M L   `   `   `  ����J  FPasswordBoxMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null`Aclr-namespace:PasswordBoxMVVM.Components;assembly=PasswordBoxMVVMPasswordBoxMVVM.Components  5      K GSimpleTrader.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:SimpleTrader.WPF.ViewsSimpleTrader.WPF.Views 5      &    SimpleTrader.WPF.Views.LoginView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      X
componentsAclr-namespace:PasswordBoxMVVM.Components;assembly=PasswordBoxMVVM     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:SimpleTrader.WPF.Views     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      $��24(�5        � 	Resources  5          BooleanToVisibilityConverter��%   &	        �� 5   
   6'   5      ��5      �� 5   
    �� ImageSource$% /Resources/login-background.jpg��5       �� Opacity$	 0.5Q�5       j� Stretch$ UniformToFill=�5      .��5      �� $��25q�6    �� Padding$ 50q�6   $��Center=�5   	   $��Center=�5   	   
�������  BrushPrimary2#��[ 5   	   $��3q�5   	    �� CornerRadius$ 10��5   	    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 10Q�6      Color$
 Gray��6/   ._�5    
   � 	 � IsSharedSizeScope$
	 True��6   
 � RowDefinitions
 5!      �� 5"      $
��auto �6    �� 5#      $
��auto �6    �� 5$      $
��auto �6    .+�5'      �� $��0��6   $��Center=�5(      $��48(�5)      $��Simple Trader��5*      �� 5,      $��1��6   $
��0 10q�6%   $��Center=�5-      $��18(�5.      $
��Thin"�5/      $5��/The world's simplest stock trading application.��50      � 52      $��2��6   $
��0 20q�6    
 53      �� 54      $
��auto �6$   �� 55      $
��auto �6$   �� 56      $
��auto �6$   �� 57      $
��auto �6$   �� 58      $
��auto �6$   .+�5;      � $��0��6   $
��0 10q�6$    � ColumnDefinitions 5<      �� 5=      $
��auto �6+    z� SharedSizeGroup$ Label��68   �� 5>      $	��300 �6+   .+�5A      �� $��0��6    $��Username��60   �� 5B      $��1��6   $��20 0 0 0q�6.   ��5C      �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�5D      � 5F      $��1��6   $
��0 10q�6$    5G      �� 5H      $
��auto �6+   $ Label��68   �� 5I      $	��300 �6+   .+�5L      �� $��0��6    $��Password��60   4   .PasswordBoxMVVM.Components.BindablePasswordBox  5M      $��1��65   $��20 0 0 0q�6E      Password 5N      �� *
Password+5O      �� 5Q      $��2��6   $
��0 10q�6&   $��Center=�5R      $��Login��5T       �� 	IsDefault$
 True��5U      $��6q�6&   ��5S      �� *LoginCommand+5U   &   �� 5W      $��3��6   $��0 10 0 0q�6&   $��Center=�5X      
������ $��Don't have an account?��5[      $��14(�5\      
����  ���5Z      �� *ViewRegisterCommand+5]      �� 5_      $��4��6   $��0 10 0 0q�6)   $��Center=�5`      
���  �� � DataContext 5a      �� *ErrorMessageViewModel+��5c      �� *	Message+y�5d      �� *
HasMessage+ �� 	Converter# [  5e      5f      5g      5h      