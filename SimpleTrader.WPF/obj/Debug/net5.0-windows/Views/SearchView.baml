   M S B A M L   `   `   `  ����K  GSimpleTrader.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SimpleTrader.WPF.ControlsSimpleTrader.WPF.Controls  5      ?$clr-namespace:SimpleTrader.WPF.ViewsSimpleTrader.WPF.Views  5      '    !SimpleTrader.WPF.Views.SearchView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      <controls'clr-namespace:SimpleTrader.WPF.Controls     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:SimpleTrader.WPF.Views     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      A =Wpf.Ui, Version=3.0.4.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5	        � 	Resources  5          BooleanToVisibilityConverter��%   &	        �� 5   
   6'   5      .��5      � $��20q�6     BrushPrimary3#���  6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   � $��0��6   $��Center=�6!   .+�5      �� $	��100��6   ��6"   �� *Symbol+ �� UpdateSourceTrigger$ PropertyChanged=��� 5      $��5 0 0 0q�6   $��Search��5      ��5      �� *SearchSymbolCommand+5      �� 5      $��5 0 0 0q�6   $
��Undo��5      ��5      �� *Undo+5      �� 5       $��5 0 0 0q�6   $
��Redo��5"      ��5!      �� *Redo+5"      5#      �� 5%   
   $��1��6   $��0 10 0 0q�6!   $��Center=�5&      
���  �� � DataContext 5'      �� *ErrorMessageViewModel+��5)      �� *	Message+y�5*      �� *
HasMessage+ �� 	Converter# [  �� 5,   
   $��2��6   $��0 10 0 0q�6!   $��Center=�5-      
��� d � 5.      �� *StatusMessageViewModel+��50      �� *	Message+y�51      �� *
HasMessage+# [  7   1SimpleTrader.WPF.Controls.SearchSymbolResultPanel  53   
   $��3��6+   $��0 20 0 0q�68   .��54      �� $��Center=�6   .+�55      � $
��0 10q�6   .+�56      �� $	��150��6    $��Shares to buy:��6,   �� 57      $��50��6   ��6)   �� *SharesToBuy+$ PropertyChanged=�58      � 59      $
��0 10q�6   .+�5:      �� $	��150��6    $��Price per share:��6,   �� 5;      $��50��6    ��6+   �� *
StockPrice+ �� StringFormat$ {0:C}��5<      �� 5=      $
��0 10q�6   $��Center=�5>      $��32(�5?      ��5@      �� *
TotalPrice+$ {0:C}���� 5A      $
��0 10q�6   $
��20 5q�6'   $	��Buy��5C      $��24(�5D      ��5B      �� *BuyStockCommand+5D      5E      5F      5H      5I      