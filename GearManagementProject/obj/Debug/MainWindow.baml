   M S B A M L   `   `   `  ����P  LGearManagementProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:GearManagementProjectGearManagementProject  5   	   &     GearManagementProject.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:GearManagementProject     5   	     � Title$  GearManagementProject��5   	   $��414.873��6'   $��623.893��68    � 
ResizeMode$ NoResize=�5	   	   .��5
      � $��0,0,2,0q�6    � ColumnDefinitions 5   
   �� 5      $
��174* �6   �� 5      $
��133* �6   .+�5   
   �� -   5         ��Name$ cboxTableName��5      $
��Left=�6*   $	��Top=�6E   $	��120��6]   $��	32,22,0,0q�6i   $��19��6|   .@�5      �� $��Units��6   �� 5      $
��Gear��6   5      �� 5   
   -   5         ��Name$ lblInfo1��5      $��Table��6"   $��10,176,337.709,209q�62   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $
��Left=�6=   $	��297��6X   $��	10,65,0,0q�6e   $	��Top=�6x   $	��588��6�   $��2��6�   ��6%   �� 6�   �� 5   
   $��0��6   $��Table
��6    $��10,10,337.709,344q�6:   �� 5   
   -   5         ��Name$ btnLoad��5      $
��Load��6"   $
��Left=�6G   $	��Top=�6b   $��61��6z   $��1��6�   $��
109,13,0,0q�6�   $��41��6�    J� RenderTransformOrigin$ 
0.68,0.314&�6�   �� 5   
   -   5        $ 	btnInsert��5      $��Insert��6$   $��318,13,235,330q�6M   $��2��6e   �� 5   
   -   5        $ 	btnUpdate��5      $��Update��6$   $��244,13,35,330q�6M   �� 5   
   -   5        $ 
btnRefresh��5      $��Refresh��6%   $��169,13,109,330q�6P   �� 5   
   -   5        $ 	btnExport��5      $��Export��6$   $
��Left=�65   $	��Top=�6P   $��75��6h   $��1��6s   $��
175,13,0,0q�6�   $��41��6�   6�   5      5      