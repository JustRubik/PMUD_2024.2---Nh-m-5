   M S B A M L   `   `   `  ����  
QuanLySVBK#    QuanLySVBK.DanhMucNganhDaoTao   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $
��Auto��5      $
��Auto��6   .��5      �� ���#F0F0F0  �� CornerRadius$  10��6"    �� Padding$ 0q�64   $	��950��6@   $	��480��6L   ._�5	   
   �  � ColumnDefinitions 5
      �� 5      $��* �6#   �� 5      $	��150 �6#   .+�5      � $��0��6   $��15q�6#    � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$   .+�5      9� $��0��6    9� 
IsExpanded$
 True��6(   $��13(�6:   $��0,0,0,10q�6H   .��5      �� $��10q�6!   .+�5      ��  �� Orientation$ 
Horizontal=�6%   $��0,0,0,10q�6>   .+�5      �� $��Mã Viện:��6(   $	��120��68   $��Center=�6D   $��13(�6_   �� 5      -   5         ��Name$ 	CboMaVien��5   '   $	��300��6:   $��Center=�6F   5      �� 5       $ 
Horizontal=�6%   $��0,0,0,10q�6>   .+�5!      �� $��Tên ngành:��6(   $	��120��6:   $��Center=�6F   $��13(�6a   �� 5"      -   5         ��Name$ TxtTenNganh��5"   &   $	��300��6;   $��Center=�6G   5#      �� 5&      $ 
Horizontal=�6%   .+�5'      �� $ 
Horizontal=�6)   $	��300��6B   .+�5(   "   �� $��Mã ngành:��6,   $	��120��6=   $��Center=�6I   $��13(�6d   �� 5)   "   -   5        $ 
TxtMaNganh��5)   *   $	��150��6>   $��Center=�6J   5*      5+      5,      5-      &   System.Windows.Controls.DataGrid  50      -   5          Name$ dgNganhDaoTao��50   (   $��1��6   	   AutoGenerateColumns$	 False��6?   $��0,10,0,0q�6[   
   Columns
 51      0  *System.Windows.Controls.DataGridTextColumn  52      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Mã ngành��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *	MaNganh+6[     53      $ Tên ngành��6-   $ * 6]    6@   �� *
TenNganh+6]     54      $ 
Mã Viện��6-   $	 120 6Y    6>   �� *MaVien+6Y     55      $ Viện quản lý��6-   $	 200 6_    6C   �� *	TenVien+6_   57      58      �� 5;      $��1��6   ���	#FFF0F0F0���	#FFCCCCCC$��1,0,0,0q�6T   $  	0 10 10 0��6n   ._�5<      �� $��Center=�6   $��10q�68   $��Stretch=�6D   .+�5=      �� -   5         ��Name$ 
BtnTimKiem��5=      $��	TÌM 🔍��61   $��0,0,0,12q�6B   $
��10,5q�6T   ���#5DADE2
�������$��SemiBold"�5>   E   5?      �� 5A      -   5        $ 
BtnThemMoi��5A      $��	THÊM ➕��61   $��0,0,0,12q�6B   $
��10,5q�6T   ���#2ECC71
�������$��SemiBold"�5B   E   5C      �� 5E      -   5        $ BtnXoa��5E      $��XÓA ❌��6-   $��0,0,0,12q�6=   $
��10,5q�6O   ���#E74C3C
�������$��SemiBold"�5F   E   5G      �� 5I      -   5        $ 
BtnCapNhat��5I      $��CẬP NHẬT 🔄��61   $��0,0,0,12q�6G   $
��10,5q�6Y   ���#9B59B6
�������$��SemiBold"�5J   E   5K      �� 5M      -	   5        $ BtnInDS��5M      $��
IN 🖨️��6.   $
��10,5q�6?   ���#F39C12
�������$��SemiBold"�5N   E   5O      5P      5Q      5R      5S      5T      