   M S B A M L   `   `   `  ����B  >Projekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ProjektProjekt  5   	       Projekt.PogodaWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Projekt     5   	     � Title$  PogodaWindow��5   	   $	��492��6   $	��548��6+   .��5	      � $��0,0,2,42q�6    � ColumnDefinitions 5
   
   �� 5      $
��100* �6   �� 5      $
��500* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ GridDetalePogody��5      $��10,0,137,-18q�6-   $	��427��6C   $��Bottom=�6P      AutoGenerateColumns .  $��2��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Data��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Data+ �� StringFormat$ {0:dd.MM.yyyy}��6m     5      $ Temperatura��6%    6:   �� *Temperatura+$ {0}°C��6r     5      $ 
Ciśnienie��6%    68   �� *
Ciśnienie+$ {0} hPa��6p   4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $ Zachmurzenie��6)    6?   �� *Zachmurzenie+6b     5      $ Deszcz��6)    69   �� *Deszcz+6V     5      $ Śnieg��6)    68   �� *Śnieg+6T   5      �� 5   
   -   5         ��Name$ ZapiszButton��5      $��Zapisz do pliku��6'   $
��Left=�6A   $��
328,54,0,0q�6\   $	��Top=�6p   $	��110��6�   $��1��6�   �� 5   
   -   5        $ DodajButton��5      $��
Dodaj wpis��6&   $��
328,79,0,0q�6;   $	��Top=�6O   $
��Left=�6�   $	��110��6�   $��1��6�   �� 5   
   -   5        $ ModyfikujButton��5      $��	Modyfikuj��6*   $
��Left=�6>   $��328,104,0,0q�6Y   $	��Top=�6n   $	��110��6�   $��1��6�   {�6�   �� 	 �� ElementName$	 GridDetalePogody��
 �� Path$
 SelectedItems.Count�6�   �� 5   
   -   5        $ 
UsunButton��5      $��Usuń��6%   $��328,129,0,0q�64   $	��Top=�6I   $
��Left=�6a   $	��110��6|   $��1��6�   {�6�   �� $	 GridDetalePogody��$
 SelectedItems.Count�6�   5      5      