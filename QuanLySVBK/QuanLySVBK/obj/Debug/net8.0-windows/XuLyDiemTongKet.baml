   M S B A M L   `   `   `  ����E  AQuanLySVBK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:QuanLySVBK
QuanLySVBK  5           QuanLySVBK.XuLyDiemTongKet   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:QuanLySVBK     5      $
��Auto��5      $
��Auto��6   .��5	      �� ���#F0F0F0  �� CornerRadius$  10��6"    �� Padding$ 10q�64   $	��950��6A   $	��480��6M   ._�5
   
   �  � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $	��150 �6#   .+�5      � $��0��6   $��0,0,10,0q�6#    � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��10 �6$   �� 5      $��* �6$   .+�5      9�  9� 
IsExpanded$
 True��6   $��13(�6-   $��0��6;   .��5      �� .+�5      ��  �� Orientation$ 
Horizontal=�6%   $��0,0,0,15q�6>   .+�5      �� $��MSSV:��6(   $	��120��65   $��Center=�6A   $��13(�6\   �� 5      -   5         ��Name$ TxtMaSinhVien��5   &   $	��200��6=   $��0,0,30,0q�6I   �� 5       $��Mã học phần:��6(   $	��120��6<   $��Center=�6H   $��13(�6c   �� 5!      -   5        $ TxtMaHP��5!   &   $	��200��67   5"      �� 5$      $ 
Horizontal=�6%   $��0,0,0,15q�6>   .+�5%      �� $��Mã ngành:��6(   $	��120��69   $��Center=�6E   $��13(�6`   �� 5&      -   5        $ 
TxtMaNganh��5&   &   $	��200��6:   $��0,0,30,0q�6F   �� 5(      $��Mã lớp học phần:��6(   $	��120��6@   $��Center=�6L   $��13(�6g   �� 5)      -   5        $ TxtMaLopHocPhan��5)   &   $	��200��6?   5*      �� 5-      $ 
Horizontal=�6%   .+�5.      �� $��
Kì học:��6(   $	��120��67   $��Center=�6C   $��13(�6^   �� 5/      -   5         ��Name$ CboKiHoc��5/   '   $	��200��69   50      51      52      &   System.Windows.Controls.DataGrid  55      -   5          Name$ dgKetQua��55   (   $��2��6   	   AutoGenerateColumns$	 False��6:   ���	#FFF0F0F0���#CCCCCC$��1q�56   H   $��0,5,0,0q�57      $��Stretch=�6,   
   Columns
 58      0  *System.Windows.Controls.DataGridTextColumn  59      ,  &System.Windows.Controls.DataGridColumn   Header$
 MSSV��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *MaSV+6T     5:      $ Mã môn học��6-   $ * 6^    6A   �� *
MaMonHoc+6^     5;      $ Tên môn học��6-   $ * 6`    6B   �� *	TenMonHoc+6`     5<      $ Số tín chỉ��6-   $ * 6^    6A   �� *
SoTinChi+6^     5=      $ Điểm��6-   $ * 6T    6;   �� *Diem+6T   5?      5@      �� 5C      $��1��6   $	��150��6%   ���	#FFF0F0F0���	#FFCCCCCC$��1,0,0,0q�6`   $  10��6z   ._�5D      �� $��Center=�6   $��10q�68   $��Stretch=�6D   .+�5F      �� -   5         ��Name$ BtnXuLy��5F      $��0,0,0,15q�6.   ���#2E86C1
�������$
��10,5q�5G      $��Stretch=�6,   $��35��6J   .��5H      �� $ 
Horizontal=�6%   $��Center=�6>   .+�5I      �� $��⚙️��6(   $��14(�62   $��0,0,5,0q�6@   �� 5J      $��XỬ LÝ��6(   $��SemiBold"�65   5K      5L      �� 5O      -   5        $ BtnInDanhSach��5O      $
��10,5q�64   $��Stretch=�6C   $��35��6a   .��5P      �� $ 
Horizontal=�6%   $��Center=�6>   .+�5Q      �� $��🖨️��6(   $��14(�63   $��0,0,5,0q�6A   �� 5R      $��IN DANH SÁCH��6(   $��SemiBold"�6<   5S      5T      5U      5V      5W      5X      5Y      