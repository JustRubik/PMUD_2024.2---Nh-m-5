   M S B A M L   `   `   `  ����  
QuanLySVBK     QuanLySVBK.DanhMucKhoaVien   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $
��Auto��5      $
��Auto��6   .��5      �� ���#F0F0F0  �� CornerRadius$  10��6"    �� Padding$ 0q�64   $	��950��6@   $	��480��6L   ._�5	   
   �  � ColumnDefinitions 5
      �� 5      $��* �6#   �� 5      $	��150 �6#   .+�5      � $��0��6   $��15q�6#    � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$   .+�5      9� $��0��6    9� 
IsExpanded$
 True��6)   $��13(�5      $��0,0,0,10q�6)   .��5      �� $��10q�6!   .+�5      ��  �� Orientation$ 
Horizontal=�6%   $��0,0,0,10q�6>   .+�5      �� $ 
Horizontal=�6)   $	��400��6B   .+�5   "   �� $��Tên Viện:��6,   $	��100��6=   $��Center=�6I   $��13(�6d   �� 5   "   -   5         ��Name$ 
TxtTenVien��5   *   $	��200��6>   $��Center=�6J   5      �� 5       $ 
Horizontal=�6)   $��20,0,0,0q�6B   .+�5!   "   �� $��Viện trưởng:��6,   $	��100��6@   $��Center=�6L   $��13(�6g   �� 5"   "   -   5        $ TxtVienTruong��5"   *   $	��200��6A   $��Center=�6M   5#      5$      �� 5'      $ 
Horizontal=�6%   $��0,0,0,10q�6>   .+�5(      �� $ 
Horizontal=�6)   $	��400��6B   .+�5)   "   �� $��Mã Viện:��6,   $	��100��6<   $��Center=�6H   $��13(�6c   �� 5*   "   -   5        $ 	TxtMaVien��5*   *   $	��200��6=   $��Center=�6I   5+      �� 5,      $ 
Horizontal=�6)   $��20,0,0,0q�6B   .+�5-   "   �� $��Website:��6,   $	��100��6<   $��Center=�6H   $��13(�6c   �� 5.   "   -   5        $ 
TxtWebsite��5.   *   $	��200��6>   $��Center=�6J   5/      50      �� 53      $ 
Horizontal=�6%   .+�54      �� $��Địa chỉ:��6(   $	��100��68   $��Center=�6D   $��13(�6_   �� 55      -   5        $ 	TxtDiaChi��55   &   $	��400��69   $��Center=�6E   56      57      58      &   System.Windows.Controls.DataGrid  5;      -   5          Name$ 
dgKhoaVien��5;   (   $��1��6      AutoGenerateColumns$ False��6<   $��0,10,0,0q�6X   	   Columns	 5<      0  *System.Windows.Controls.DataGridTextColumn  5=      ,  &System.Windows.Controls.DataGridColumn
   Header$
 
Mã Viện��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *MaVien+6Y     5>      $
 Tên Viện��6-   $ * 6[    6?   �� *	TenVien+6[     5?      $
 Viện trưởng��6-   $
 auto 6a    6B   �� *
VienTruong+6a     5@      $
 Website��6-   $ * 6Z    6>   �� *	Website+6Z     5A      $
 Địa chỉ văn phòng��6-   $ * 6k    6H   �� *DiaChiVanPhong+6k   5D      5E      �� 5H      $��1��6   ���	#FFF0F0F0���	#FFCCCCCC$��1,0,0,0q�6T   $  	0 10 10 0��6n   ._�5I      �� $��Center=�6   $��10q�68   $��Stretch=�6D   .+�5J      �� -   5         ��Name$ 
BtnTimKiem��5J      $��	TÌM 🔍��61   $��0,0,0,12q�6B   $
��10,5q�6T   ���#5DADE2
�������$��SemiBold"�5K   E   5L      �� 5N      -   5        $ 
BtnThemMoi��5N      $��	THÊM ➕��61   $��0,0,0,12q�6B   $
��10,5q�6T   ���#2ECC71
�������$��SemiBold"�5O   E   5P      �� 5R      -	   5        $ BtnXoa��5R      $��XÓA ❌��6-   $��0,0,0,12q�6=   $
��10,5q�6O   ���#E74C3C
�������$��SemiBold"�5S   E   5T      �� 5V      -
   5        $ 
BtnCapNhat��5V      $��CẬP NHẬT 🔄��61   $��0,0,0,12q�6G   $
��10,5q�6Y   ���#9B59B6
�������$��SemiBold"�5W   E   5X      �� 5Z      -   5        $ BtnInDS��5Z      $��
IN 🖨️��6.   $
��10,5q�6?   ���#F39C12
�������$��SemiBold"�5[   E   5\      5]      5^      5_      5`      5a      