   M S B A M L   `   `   `  ����K  GSimpleTrader.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SimpleTrader.WPF.ControlsSimpleTrader.WPF.Controls  5      ?$clr-namespace:SimpleTrader.WPF.ViewsSimpleTrader.WPF.Views  5      %    SimpleTrader.WPF.Views.SellView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      <controls'clr-namespace:SimpleTrader.WPF.Controls     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:SimpleTrader.WPF.Views     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � 	Resources  5          BooleanToVisibilityConverter��%   &	        �� 5   
   6'   5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� -   5         ��Name$ cbAssets��5      $��0��5      $	��300��5      ��5      �� *AssetListingViewModel.Assets+ �� SelectedItem 5      �� *SelectedAsset+��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5       �� ��6$   �� *Symbol+�� 5!      $
��10 0q�6!   
���   �$��1 0 0 0q�5#      �� 5$      ��6$   �� *Shares+5%      5&      5(      �� 5*   
   $��1��6   $��0 10 0 0q�6!   $��Center=�5+      
���  �� � DataContext 5,      �� *ErrorMessageViewModel+��5.      �� *	Message+y�5/      �� *
HasMessage+ �� 	Converter# [  �� 51   
   $��2��6   $��0 10 0 0q�6!   $��Center=�52      
��� d � 53      �� *StatusMessageViewModel+��55      �� *	Message+y�56      �� *
HasMessage+# [  7   1SimpleTrader.WPF.Controls.SearchSymbolResultPanel  58   
   $��3��6+   $��0 20 0 0q�68   .��59      �� $��Center=�6   .+�5:      � $
��0 10q�6   .+�5;      �� $	��150��6      Shares to sell#���  6,   �� 5<      $��50��6   ��6)   �� *SharesToSell+ �� UpdateSourceTrigger$ PropertyChanged=�5=      � 5>      $
��0 10q�6   .+�5?      �� $	��150��6      Price per share#���  6,   �� 5@      $��50��6    ��6+   �� *
StockPrice+ �� StringFormat$ {0:C}��5A      �� 5B      $
��0 10q�6   $��Center=�5C      $��32(�5D      ��5E      �� *
TotalPrice+$ {0:C}��� 5F      $��Center=�6   .+�5G      �� $��10 10q�6   $
��20 5q�6,     Add to Queue#���  5I      $��24(�5J      ��5H      �� *ShowAddToQueueCommand+5J      �� 5K      $��10 10q�6   $
��20 5q�6,     Sell#���  5M      $��24(�5N      ��5L      �� *SellStockCommand+5N      5P      5R      5S      5T      5U      