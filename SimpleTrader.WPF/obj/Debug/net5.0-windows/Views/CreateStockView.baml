   M S B A M L   `   `   `  ����K  GSimpleTrader.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:SimpleTrader.WPF.ViewsSimpleTrader.WPF.Views  5      ,    &SimpleTrader.WPF.Views.CreateStockView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:SimpleTrader.WPF.Views     5      A =Wpf.Ui, Version=3.0.4.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5      .��5
      � $	��400��6   $
��1000��6   $��Center=�6*     � RowDefinitions  5   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   .+�5   
   �� $
��Left=�6   $��36(�6/   $��SemiBold"�6=   Create stock6b   �� 5   
   $��1��6   .+�5      �� $��Symbol��6   $��
 15 0 0 0 q�6%     Wpf.Ui.Controls.TextBox  5      $	��200��5      $	��500��6       PlaceholderText$ Enter symbol��5      $��
10 0 0  10q�5      ��5      �� *Symbol+ �� UpdateSourceTrigger$ PropertyChanged=�5       �� 5!   
   $��2��6   .+�5"      �� $��Price��6   $��
 15 0 0 0 q�6$     Wpf.Ui.Controls.NumberBox  5#      $	��200��6   $	��500��6*   $��	10 0 0 10q�5$         MaxDecimalPlaces$ 2��5%      $ Enter price��5&         Value 5'      �� *Price+$ PropertyChanged=�5)      �� 5+   
   $��3��6   .+�5,      �� $��Description��6   $��
 15 0 0 0 q�6*     5-      $	��200��5.      $	��500��6(    �� TextWrapping$
 Wrap=�5/      $��	10 0 0 10q�50      $ Enter description��52      ��51      �� *Description+$ PropertyChanged=�52      53      �� 55   
   $��4��6   .+�56      �� $��Company Name��6   $��
 15 0 0 0 q�6+     57      $	��200��58      $	��500��6(   $��	10 0 0 10q�59      $ Enter company name��5;      ��5:      �� *CompanyName+$ PropertyChanged=�5;      5<      �� 5@   
   $��5��6   .+�5A      �� $��Exchange Name��6   $��
 15 0 0 0 q�6,   �� 5B      -   5        $
��Left=�5B       �� SelectedIndex$ 0��69   $	��500��5C      $��	10 0 0 10q�5D      .@�5G      �� $	��500��6   Nasdaq60   �� 5H      $	��500��6   	Dow Jones63   �� 5I      $	��500��6   	S&P 50065   5J      5K      �� 5L   
   $��6��6   $
��Left=�6"   $��5 0 0 0q�6=   .+�5M      �� $	��100��6+   ��6   �� *Img+6+   �� 5N      -   5        .��5N   ,   Select Image6:   5O      �� 5R   
   $��7��68   ��6   �� *CreateStockCommand+.��6E   Create6M   5S      5T      