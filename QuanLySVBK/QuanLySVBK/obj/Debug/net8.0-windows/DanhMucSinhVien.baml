   M S B A M L   `   `   `  ����  
QuanLySVBK     QuanLySVBK.DanhMucSinhVien   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $
��Auto��5      $
��Auto��6   .��5      �� ���#F0F0F0  �� CornerRadius$  10��6"    �� Padding$ 0q�64   $	��950��6@   $	��480��6L   ._�5	   
   �  � ColumnDefinitions 5
      �� 5      $��* �6#   �� 5      $	��150 �6#   .+�5      � $��0��6   $��15q�6#    � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$   .+�5      9�  9� 
IsExpanded$
 True��6   .��5      �� $��	0,10,0,10q�6!   .+�5      ��  �� Orientation$ 
Horizontal=�6%   $��0,0,0,8q�6>   .+�5      �� $ 
Horizontal=�6)   $	��400��6B   .+�5   "   �� $��
Họ tên:��6,   $	��100��6;   $��Center=�6G   $��13(�6b   �� 5   "   -   5         ��Name$ TxtHoTen��5   *   $	��200��6<   $��Center=�6H   5      �� 5      $ 
Horizontal=�6)   $��20,0,0,0q�6B   .+�5    "   �� $��Giới tính:��6,   $��80��6>   $��Center=�6I   $��13(�6d   	� 5!   "   -   5         	�Name$ RbNam��5!   .   $	��Nam��6=   $��5,0,0,0q�6K    	� 	GroupName$ GioiTinh��6\   $��Center=�6q   	� 5"   "   -   5        $
 RbNu��5"   .   $
��Nữ��6<   $��15,0,0,0q�6I   $ GioiTinh��6[   $��Center=�6p   5#      5$      �� 5'      $ 
Horizontal=�6%   $��0,0,0,8q�6>   .+�5(      �� $ 
Horizontal=�6)   $	��400��6B   .+�5)   "   �� $��Mã ngành:��6,   $	��100��6=   $��Center=�6I   $��13(�6d   �� 5*   "   -   5        	 ��Name$	 
TxtMaNganh��5*   +   $	��200��6?   $��Center=�6K   5+      �� 5,      $ 
Horizontal=�6)   $��20,0,0,0q�6B   .+�5-   "   �� $��Ngày sinh:��6,   $��80��6>   $��Center=�6I   $��13(�6d   (  "System.Windows.Controls.DatePicker  5.   "   -   5        
  Name$
 
DpNgaySinh��5.   -   $	��150��6A   $��Center=�6M   5/      50      �� 53      $ 
Horizontal=�6%   $��0,0,0,8q�6>   .+�54      �� $��Mã SV:��6(   $	��100��66   $��Center=�6B   $��13(�6]   �� 55      -   5        $ TxtSinhVien��55   &   $	��200��6;   $��Center=�6G   56      �� 59      $ 
Horizontal=�6%   $��0,0,0,8q�6>   .+�5:      �� $��Quê quán:��6(   $	��100��69   $��Center=�6E   $��13(�6`   �� 5;      -   5        $	 
CboQueQuan��5;   '   $	��200��6;   $��Center=�6G   5=      �� 5@      $ 
Horizontal=�6%   .+�5A      �� $ 
Horizontal=�6)   $	��400��6B   .+�5B   "   �� $��	Số ĐT:��6,   $	��100��6:   $��Center=�6F   $��13(�6a   �� 5C   "   -   5        $ TxtSoDienThoai��5C   *   $	��200��6B   $��Center=�6N   5D      �� 5E      $ 
Horizontal=�6)   $��20,0,0,0q�6B   .+�5F   "   �� $��
Số CCCD:��6,   $��80��6<   $��Center=�6G   $��13(�6b   �� 5G   "   -	   5        $ TxtCCCD��5G   *   $	��200��6;   $��Center=�6G   5H      5I      5J      5K      &   System.Windows.Controls.DataGrid  5N      -
   5          Name$ 
dgSinhVien��5N   (   $��1��6      AutoGenerateColumns$ False��6<   $��0,10,0,0q�6X      Columns 5O      0  *System.Windows.Controls.DataGridTextColumn  5P      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã SV��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6U   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *MaSV+6U     5Q      $ 	Họ tên��6-   $ * 6W    6=   �� *HoTen+6W     5R      $ Giới tính��6-   $
 auto 6]    6@   �� *
GioiTinh+6]     5S      $ 
Ngày sinh��6-    6@   �� *
NgaySinh+ �� StringFormat$ 
dd/MM/yyyy��  5T      $ 
Quê quán��6-   $
 auto 6[    6?   �� *	QueQuan+6[     5U      $
 CCCD��6-   $ * 6^    6;   �� *CanCuocCongDan+6^     5V      $ Số ĐT��6-   $
 auto 6\    6<   �� *SoDienThoai+6\     5W      $ 
Mã ngành��6-   $ * 6[    6?   �� *	MaNganh+6[   5Y      5Z      �� 5]      $��1��6   ���	#FFF0F0F0���	#FFCCCCCC$��1,0,0,0q�6T   $  	0 10 10 0��6n   ._�5^      �� $��Center=�6   $��10q�68   $��Stretch=�6D   .+�5_      �� -   5         ��Name$ 
BtnTimKiem��5_      $��	TÌM 🔍��61   $��0,0,0,12q�6B   $
��10,5q�6T   ���#5DADE2
�������$��SemiBold"�5`   E   5a      �� 5c      -   5        $ 
BtnThemMoi��5c      $��	THÊM ➕��61   $��0,0,0,12q�6B   $
��10,5q�6T   ���#2ECC71
�������$��SemiBold"�5d   E   5e      �� 5g      -   5        $ BtnXoa��5g      $��XÓA ❌��6-   $��0,0,0,12q�6=   $
��10,5q�6O   ���#E74C3C
�������$��SemiBold"�5h   E   5i      �� 5k      -   5        $ BtnLuu��5k      $��	LƯU 💾��6-   $��0,0,0,12q�6>   $
��10,5q�6P   ���#9B59B6
�������$��SemiBold"�5l   E   5m      �� 5o      -   5        $ BtnInDS��5o      $��
IN 🖨️��6.   $
��10,5q�6?   ���#F39C12
�������$��SemiBold"�5p   E   5q      5r      5s      5t      5u      5v      