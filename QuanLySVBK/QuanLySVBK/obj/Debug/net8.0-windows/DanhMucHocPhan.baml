   M S B A M L   `   `   `  ����  
QuanLySVBK    QuanLySVBK.DanhMucHocPhan   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $
��Auto��5      $
��Auto��6   .��5      �� ���#F0F0F0  �� CornerRadius$  10��6"    �� Padding$ 0q�64   $	��950��6@   $	��480��6L   ._�5	   
   �  � ColumnDefinitions 5
      �� 5      $��* �6#   �� 5      $	��150 �6#   .+�5      � $��0��6   $��15q�6#    � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$   .+�5      9� $��0��6    9� 
IsExpanded$
 True��6(   $��13(�6:   $��0,0,0,10q�6H   .��5      �� $��10q�6!   .+�5      ��  �� Orientation$ 
Horizontal=�6%   $��0,0,0,10q�6>   .+�5      �� $��Tên học phần:��6(   $	��120��6=   $��Center=�6I   $��13(�6d   �� 5      -   5         ��Name$ TxtTenHP��5   &   $	��400��68   $��Center=�6D   5      �� 5       $ 
Horizontal=�6%   $��0,0,0,10q�6>   .+�5!      �� $ 
Horizontal=�6)   $	��400��6B   .+�5"   "   �� $��Mã học phần:��6,   $	��120��6@   $��Center=�6L   $��13(�6g   �� 5#   "   -   5        $ TxtMaHP��5#   *   $	��200��6;   $��Center=�6G   5$      5%      �� 5(      $ 
Horizontal=�6%   .+�5)      �� $ 
Horizontal=�6)   $	��400��6B   .+�5*   "   �� $��Mã Viện:��6,   $	��120��6<   $��Center=�6H   $��13(�6c   �� 5+   "   -   5         ��Name$ 	CboMaVien��5+   +   $	��200��6>   $��Center=�6J   5,      �� 5-      $ 
Horizontal=�6)   $��20,0,0,0q�6B   .+�5.   "   �� $��Số tín chỉ:��6,   $	��100��6?   $��Center=�6K   $��13(�6f   �� 5/   "   -   5        $ TxtSoTinChi��5/   *   $	��100��6?   $��Center=�6K   50      51      52      53      &   System.Windows.Controls.DataGrid  56      -   5          Name$ 	dgHocPhan��56   (   $��1��6   	   AutoGenerateColumns$	 False��6;   $��0,10,0,0q�6W   
   Columns
 57      0  *System.Windows.Controls.DataGridTextColumn  58      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã HP��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6U   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *MaHP+6U     59      $ Tên HP��6-   $ * 6W    6=   �� *TenHP+6W     5:      $ 
Mã Viện��6-   $	 100 6Y    6>   �� *MaVien+6Y     5;      $ Số TC��6-   $ 80 6Y    6<   �� *
SoTinChi+6Y   5=      5>      �� 5A      $��1��6   ���	#FFF0F0F0���	#FFCCCCCC$��1,0,0,0q�6T   $  	0 10 10 0��6n   ._�5B      �� $��Center=�6   $��10q�68   $��Stretch=�6D   .+�5C      �� -   5         ��Name$ 
BtnTimKiem��5C      $��	TÌM 🔍��61   $��0,0,0,12q�6B   $
��10,5q�6T   ���#5DADE2
�������$��SemiBold"�5D   E   5E      �� 5G      -   5        $ 
BtnThemMoi��5G      $��	THÊM ➕��61   $��0,0,0,12q�6B   $
��10,5q�6T   ���#2ECC71
�������$��SemiBold"�5H   E   5I      �� 5K      -   5        $ BtnXoa��5K      $��XÓA ❌��6-   $��0,0,0,12q�6=   $
��10,5q�6O   ���#E74C3C
�������$��SemiBold"�5L   E   5M      �� 5O      -	   5        $ 
BtnCapNhat��5O      $��CẬP NHẬT 🔄��61   $��0,0,0,12q�6G   $
��10,5q�6Y   ���#9B59B6
�������$��SemiBold"�5P   E   5Q      �� 5S      -
   5        $ BtnInDS��5S      $��
IN 🖨️��6.   $
��10,5q�6?   ���#F39C12
�������$��SemiBold"�5T   E   5U      5V      5W      5X      5Y      5Z      