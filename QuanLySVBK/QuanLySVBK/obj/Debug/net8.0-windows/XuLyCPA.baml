   M S B A M L   `   `   `  ����E  AQuanLySVBK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:QuanLySVBK
QuanLySVBK  5          QuanLySVBK.XuLyCPA   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:QuanLySVBK     5      $
��Auto��5      $
��Auto��6   .��5	      �� ���#F0F0F0  �� CornerRadius$  10��6"    �� Padding$ 0q�64   $	��950��6@   $	��480��6L   ._�5
   
   �  � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      � $��0��6   $��10q�6#    � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$   .+�5      9�  9� 
IsExpanded$
 True��6   $��13(�6-   $��0��6;   .��5      �� .+�5      ��  �� Orientation$ 
Horizontal=�6%   $��0,0,0,10q�6>   .+�5      �� $��MSSV:��6(   $	��120��65   $��Center=�6A   $��13(�6\   �� 5      -   5         ��Name$ TxtMaSinhVien��5   &   $	��200��6=   5      �� 5!      $ 
Horizontal=�6%   $��0,0,0,10q�6>   .+�5"      �� $��
Kì học:��6(   $	��120��67   $��Center=�6C   $��13(�6^   �� 5#      -   5         ��Name$ CboKiHoc��5#   '   $	��200��69   �� 5$      -   5         ��Name$ ChkCPA��5$   (   $ ��*CPA tính đến kì này��68   $��10,0,0,0q�6T   $��Center=�6f   
���  ��6�   5%      5'      5(      &   System.Windows.Controls.DataGrid  5+      -   5        	  Name$	 dgKetQua��5+   (   $��1��6   
   AutoGenerateColumns$
 False��6:      Columns 5,      0  *System.Windows.Controls.DataGridTextColumn  5-      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã sinh viên��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6\   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *MaSV+6\     5.      $ Mã môn học��6-   $ * 6^    6A   �� *
MaMonHoc+6^     5/      $ 	Mã lớp��6-   $
 auto 6W    6=   �� *MaLop+6W     50      $ Mã kì��6-   $ * 6U    6<   �� *MaKi+6U     51      $ Số tín chỉ��6-   $
 Auto 6^    6A   �� *
SoTinChi+6^     52      $ Điểm��6-   $ * 6T    6;   �� *Diem+6T   54      55      �� 58      $��1��6   $	��150��6%   ���	#FFF0F0F0���	#FFCCCCCC$��1,0,0,0q�6`   $  10��6z   ._�59      �� $��Center=�6   $��10q�68   $��Stretch=�6D   .+�5;      �� -   5         ��Name$ BtnXuLy��5;      $��0,0,0,15q�6.   ���#2E86C1
�������$
��10,5q�6h   $��Stretch=�6w   .��5<      �� $ 
Horizontal=�6%   $��Center=�6>   .+�5=      �� $��⚙️��6(   $��14(�62   $��0,0,5,0q�6@   �� 5>      $��XỬ LÝ��6(   $��SemiBold"�65   5?      5@      �� 5C      -   5        $ BtnInDanhSach��5C      $
��10,5q�64   $��Stretch=�6C   .��5D      �� $ 
Horizontal=�6%   $��Center=�6>   .+�5E      �� $��🖨️��6(   $��14(�63   $��0,0,5,0q�6A   �� 5F      $��IN DANH SÁCH��6(   $��SemiBold"�6<   5G      5H      5I      5J      5K      5L      5M      