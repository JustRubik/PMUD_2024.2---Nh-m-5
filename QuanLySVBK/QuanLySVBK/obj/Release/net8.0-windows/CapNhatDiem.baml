   M S B A M L   `   `   `  ���� E  AQuanLySVBK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:QuanLySVBK
QuanLySVBK      QuanLySVBK.CapNhatDiem   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:QuanLySVBK     $
��Auto��$
��Auto��.���� ���#F0F0F0  �� CornerRadius$  10�� �� Padding$ 0q�$	��950��$	��480��._��  � RowDefinitions �� $
��Auto ��� $��* �.+�� $��10 10 10 10q� � ColumnDefinitions �� $
��Auto ��� $	��150 ��� $
��Auto ��� $	��150 ��� $
��Auto ��� $	��100 � �� $
��Auto ��� $
��Auto �.+��� $��MSSV:��$��0��$��Center=�$��13(�$��0,0,5,0q��� -    ��Name$ TxtMSSV��$��1��$��Center=�$��13(�$��0,5,20,5q��� $��Mã học phần:��$��2��$��Center=�$��13(�$��10,0,5,0q��� -   $ TxtMaHP��$��3��$��Center=�$��13(�$��0,5,20,5q��� $��Điểm GK:��$��4��$��Center=�$��13(�$��10,0,5,0q��� -   $ 	TxtDiemGK��$��5��$��Center=�$��13(�$��0,5,0,5q��� $��
Kì học:��$��1��$��0��$��Center=�$��13(�$��0,0,5,0q��� -    ��Name$ CboKiHoc��$��1��$��1��$��Center=�$��13(�$��0,0,20,0q��� $��Mã lớp học phần:��$��1��$��2��$��Center=�$��13(�$��10,0,5,0q��� -   $ TxtMaLopHocPhan��$��1��$��3��$��Center=�$��13(�$��0,0,20,0q��� $��Điểm CK:��$��1��$��4��$��Center=�$��13(�$��10,0,5,0q��� -   $ 	TxtDiemCK��$��1��$��5��$��Center=�$��13(�� $��1��$��
10 0 10 10q� �� $��* ��� $	��150 �.+�&   System.Windows.Controls.DataGrid  -     Name$ dgKetQua��   AutoGenerateColumns$ False��$��0��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   Header$	 Mã môn học��
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 auto 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
MaMonHoc+  $	 Tên môn học��$	
 300  �� *	TenMonHoc+  $	 Số tín chỉ��$
 *  �� *
SoTinChi+  $	 
Điểm GK��$
 *  �� *DiemGK+  $	 
Điểm CK��$
 *  �� *DiemCK+�� $��1�����	#FFF0F0F0���	#FFCCCCCC$��1,0,0,0q�$  	0 10 10 0��._��� $��Center=�$��10q�$��Stretch=�.+��� -    ��Name$ 
BtnTimKiem��$��TÌM KIẾM 🔍��$��0,0,0,15q�$
��10,5q�$��Stretch=����#5DADE2
�������$��SemiBold"��� -	   $ BtnThem��$��	THÊM ➕��$��0,0,0,15q�$
��10,5q�$��Stretch=����#2ECC71
�������$��SemiBold"��� -
   $ BtnXoa��$��XÓA ❌��$��0,0,0,15q�$
��10,5q�$��Stretch=����#E74C3C
�������$��SemiBold"��� -   $ 
BtnCapNhat��$��CẬP NHẬT 🔄��$
��10,5q�$��Stretch=����#9B59B6
�������$��SemiBold"�