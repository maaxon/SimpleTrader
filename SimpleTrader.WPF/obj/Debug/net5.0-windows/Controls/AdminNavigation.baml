   M S B A M L   `   `   `  ����K  GSimpleTrader.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SimpleTrader.WPF.ControlsSimpleTrader.WPF.Controls  5      I)clr-namespace:SimpleTrader.WPF.ConvertersSimpleTrader.WPF.Converters  5      U/clr-namespace:SimpleTrader.WPF.State.Navigators!SimpleTrader.WPF.State.Navigators  5      I)clr-namespace:SimpleTrader.WPF.ViewModelsSimpleTrader.WPF.ViewModels  5	      /    )SimpleTrader.WPF.Controls.AdminNavigation   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:SimpleTrader.WPF.Controls     5      @
converters)clr-namespace:SimpleTrader.WPF.Converters     5      ?nav/clr-namespace:SimpleTrader.WPF.State.Navigators     5      8vm)clr-namespace:SimpleTrader.WPF.ViewModels     5	        � 	Resources  5      @   :SimpleTrader.WPF.Converters.EqualValueToParameterConverter "  EqualValueToParameterConverter��%   &	          5   
   64   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   � $��0��6     BrushPrimary1#���  6   .+�5      ��  �� Padding$ 10q�6   $
��1000��5      $��28(�5      
�������  TitleMainWindow#���  5      5      � 5   
   $��1��6     BrushPrimary2#���  5       �� EdgeMode$ Aliased=�5      .+�5       � $
��1000��6     5!        	NavButton �� BasedOn �� 
TargetType��%+   '	�       7  �� 5"      8   " 	�6A   5#       � ColumnDefinitions 5$      �� 5%      $
��auto �6'   �� 5&      $
��auto �6'   �� 5'      $
��auto �6'   �� 5(      $
��auto �6'   �� 5)      $
��auto �6'   �� 5*      $��* �6'   .+�5-      	� $��0��6   0   *SimpleTrader.WPF.State.Navigators.ViewType   Home#��Z 5/        Home#���  50      ��5.      �� *UpdateCurrentViewModelCommand+ d� 	IsChecked 51      �� *CurrentViewModel+	 �� Mode$	 OneWay=�
 �� 	Converter#
 [   �� ConverterParameter/   )SimpleTrader.WPF.ViewModels.HomeViewModel"  	� 52      $��1��6   
   Buy#��Z 54        Buy#���  55      ��53      �� *UpdateCurrentViewModelCommand+ 56      �� *CurrentViewModel+$	 OneWay=�#
 [  .   (SimpleTrader.WPF.ViewModels.BuyViewModel"  	� 57      $��2��6      	Portfolio#��Z 59        	Portfolio#���  5:      ��58      �� *UpdateCurrentViewModelCommand+ 5;      �� *CurrentViewModel+$	 OneWay=�#
 [  4   .SimpleTrader.WPF.ViewModels.PortfolioViewModel"  	� 5<      $��3��6      Users#��Z 5>       	 Users#���  5?      ��5=      �� *UpdateCurrentViewModelCommand+ 5@      �� *CurrentViewModel+$	 OneWay=�#
 [  0   *SimpleTrader.WPF.ViewModels.UsersViewModel"  	� 5A      $��4��6      AdminStocks#��Z 5C       
	 Stocks#��� 	 5D      ��5B      �� *UpdateCurrentViewModelCommand+ 5E      �� *CurrentViewModel+$	 OneWay=�#
 [  6   0SimpleTrader.WPF.ViewModels.AdminStocksViewModel"  5G      5H      5I      5J      