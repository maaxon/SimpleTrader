   M S B A M L   `   `   `  ����K  GSimpleTrader.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SimpleTrader.WPF.ControlsSimpleTrader.WPF.Controls  5      ?$clr-namespace:SimpleTrader.WPF.ViewsSimpleTrader.WPF.Views  5      E'clr-namespace:SimpleTrader.WPF.ControlsSimpleTrader.WPF.Controls  5	      P LLoadingSpinnerControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\Bclr-namespace:LoadingSpinnerControl;assembly=LoadingSpinnerControlLoadingSpinnerControl 5
      $    SimpleTrader.WPF.Views.BuyView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      <controls'clr-namespace:SimpleTrader.WPF.Controls     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:SimpleTrader.WPF.Views     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      =	controlls'clr-namespace:SimpleTrader.WPF.Controls     5	      UcustomBclr-namespace:LoadingSpinnerControl;assembly=LoadingSpinnerControl     5
      A =Wpf.Ui, Version=3.0.4.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5        � 	Resources  5          BooleanToVisibilityConverter��%   &	        �� 5   
   6'   5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   � $��0��6   $��Center=�6!   .+�5      �� -   5        $	��800��5      $	��300��6%   ��64   �� *Symbol+ �� UpdateSourceTrigger$ PropertyChanged=�5   4   �� 5!      $��5 0 0 0q�6     Filters#���  5#      ��5"      �� *ShowFilters+5#      5$      �� 5'   
   $��1��6   $��0 10 0 0q�6!   $��Center=�5(      
���  �� � DataContext 5)      �� *ErrorMessageViewModel+��5+      �� *	Message+y�5,      �� *
HasMessage+ �� 	Converter# [  �� 5.   
   $��1��6   $��0 10 0 0q�6!   $��Center=�5/      
��� d � 50      �� *StatusMessageViewModel+��52      �� *	Message+y�53      �� *
HasMessage+# [  � 54   
   $��1��6   $
��0 10q�6   ��55      �� 56       �� 
TargetType" �6   .�57      ��  �� Property � y� �� Value$ 	Collapsed=�63    �� Triggers 58      �� 59      	 �� Binding	 6&   �� *	IsLoading+
 �� Value	
 False6D   .a�5:      ��  � y�$ Visible=�6;   5;      5=      .+�5?      ��  �� Padding$ 16q�5@      $��2,2,2,2q�5C       �� CornerRadius$ 8,8,8,8��5D      $
��1000��5E      ��5A      *  $Wpf.Ui.Markup.ThemeResourceExtension  *%#CardBackgroundFillColorDefaultBrush+��5B        *CardStrokeColorDefaultBrush+._�5G      �� .+�5I      � $��
10 0 0 10 q�6    � ColumnDefinitions 5J      �� 5K      $��* �6/   6;   �� 5L      $��* �6/   6;   �� 5M      $��* �6/   6;   �� 5N      $��* �6/   6;   .+�5P      �� $��SemiBold"�6$   $
�� 5 0q�6:    
 Symbol#���  6H   �� 5Q      $��SemiBold"�6$   $��Center=�6:   $
�� 5 0q�6W   $��1��6e    	 Price#���  6u   �� 5R      $��SemiBold"�6$   $��Center=�6:   $
�� 5 0q�6W   $��2��6e     Company#���  6u   �� 5S      $��SemiBold"�6$   $��Center=�6:   $��0 0 13 0q�6W   $��3��6i     Exchange#���  6y   5T        Wpf.Ui.Controls.ListView  5V       �� SelectionMode$ Single=�5X       �� SelectedIndex$ 0��5Y      $	��300��5Z      ��5W      �� *cardViewModels+��5\      �� 5]      .R�5^      )   #SimpleTrader.WPF.Controls.AssetCard  5_      5a      5b      5c      5e      � 5i   
   $��1��6   $��0 20 0 0q�6   ��5j      �� 5k      " �6   .�5l      ��  � y�$ 	Collapsed=�63    5m      �� 5n      	 6&   �� *	IsLoading+
 True6D   .a�5o      ��  � y�$ Visible=�6;   5p      5r       5u      �� 5v      $
��auto �6    �� 5w      $
��auto �6    .+�5z      *  $LoadingSpinnerControl.LoadingSpinner  $��0��5{         	Thickness$ 5Q�5}        BrushPrimary2   Color# [ 5~         	IsLoading 5|      �� *	IsLoading+5~      �� 5�      $��1��5�      $��20q�5�      $��14(�5�      $��
Loading...��5�       �� TextAlignment$ Center=�5�      5�      5�      5�      