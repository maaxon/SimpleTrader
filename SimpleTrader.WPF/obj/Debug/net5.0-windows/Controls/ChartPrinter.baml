   M S B A M L   `   `   `  ����K  GSimpleTrader.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SimpleTrader.WPF.ControlsSimpleTrader.WPF.Controls  5      C&clr-namespace:SimpleTrader.WPF.HelpersSimpleTrader.WPF.Helpers  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      C&clr-namespace:SimpleTrader.WPF.HelpersSimpleTrader.WPF.Helpers  5	      ,    &SimpleTrader.WPF.Controls.ChartPrinter   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:SimpleTrader.WPF.Controls     5      5my&clr-namespace:SimpleTrader.WPF.Helpers     5      6sys&clr-namespace:System;assembly=mscorlib     5      :helpers&clr-namespace:SimpleTrader.WPF.Helpers     5	        � 	Resources  5         trfFlip �� ScaleY  	tplCanvas  styFlipContainer �� 
TargetType �� Property �� Value �� BasedOn  tplLabel �� DataType �� StringFormat  styLabel  styLabelLeft  styLabelRight  tplLineHorizontal �� StrokeDashArray  	styCandle	 �� Triggers
 �� Binding �� Value 	 tplCandleLine 
 styCandleLine  tplCandleRect  styCandleRect��%�  &	        &	      &	 D     7   '�� �     7  7  '��     7  &	 0    7   &	 �    &	     7  &	 T    7  &	 �    &	 '    &		 5    7  &	
 �    &	 #    7  &	 �    �� 5   
   $ -1Q�6)   �� 5   
   .R�5      �� 5      �� 5   
   " �6)   .�5      ��  �@J�RenderTransformOrigin$ .5 .5&�66   �� 5       � z�8   60   5      �� 5   
   " ��6   8   .�5      ��  � ��8  6+   5      �� 5   
   " ��6   8   6$   �� 5   
   $ 
sys:Double��6(   .R�5      �� $��0 8 0 -8q�6=   
�������8z�  ��6   �� *.+$	 0.0��6e   5      �� 5   
   " ��6!   .�5      ��  �@��Top 6+   �� 5      �� 5   
   " ��6%   8   .�5       ��  �@��Right$ 10��6-   5!      �� 5"   
   " ��6&   8   .�5#      ��  �@��Left$ 10��6,   5$      �� 5%   
   $ 
sys:Double��61   .R�5&      �� 
�������$	 4 8R�6&   $��1��6<   $	��500��6P   $��1��6\   5'      �� 5(   
   " ��6"   .�5)      ��  � ��
 � E��6'   �� 5*       � ��
 �  ��6%   	 5+      �� 5,      
 6   �� *
IsPositive+ True6=   .a�5-      ��  � ��
 � �|�6/   �� 5.       � ��
 �"�"�6-   5/      51      �� 52   
   $ 	my:Candle��6-   .R�53      �� 8��  $��2��6;   ��6E   �� *Height+54      �� 55   
   " ��6&   .�56      ��  �@��Left 6,   �� *Date+�� 57       �@��Top 6+   �� *Min+58      �� 59   
   $ 	my:Candle��6-   .R�5:      �� 8��  $��6��6;   $��-2 0 2 0q�6d   ��6E   �� *DeltaHeight+6d   5;      �� 5<   
   " ��6&   .�5=      ��  �@��Left 6,   �� *Date+�� 5>       �@��Top 6+   �� *
DeltaMin+5?      5@      .��5A      � $��
0 70 0 -70q�6*   ��6   �� *PriceHeight+ � ColumnDefinitions 5B   
   �� 5C      $��50 �6   �� 5D      $	��500 �6   �� 5E      $��50 �6   .+�5G   
   �� $��0��6   #��[ 5H      #��[ 6:   ��5G   '   �� *Labels+5H   :   �� 5I   
   $��1��6   #��[ 5J      #��[ 6C   ��5I   '   �� *Labels+5J   C   �� 5K   
   $��1��6   #��[	 5L      #��[
 6?   ��5K   '   �� *	Candles+5L   ?   �� 5M   
   $��1��6   #��[ 5N      #��[ 6?   ��5M   '   �� *	Candles+5N   ?   �� 5O   
   $��2��6   #��[ 5P      #��[ 6:   ��5O   '   �� *Labels+5P   :   �� 5Q   
   $��1��6   .+�5R      �� 
�������$	��500��6O   $��2��6[   
 �� Top 6   �� *PriceCurrent+6[   5S      �� 5T   
   $��2��6   .+�5U      �� $��
6 10 0 -10q�69   
������� �� CornerRadius$ 3��5V   ,   #z�[  6=    5U      �� *PriceCurrent+._�5W      �� 
���iii�$	��4 2q�6a   ��6   �� *PriceCurrent+$	 0.0��6a   5X      5Y      5Z      5[      