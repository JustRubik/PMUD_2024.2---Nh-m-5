   M S B A M L   `   `   `  ����   
QuanLySVBK-    'QuanLySVBK.Accounts.TraCuuKetQuaControl   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .��� $��10q�.+��� 
�������  �� CornerRadius$  10�����#F02A2A$��2q� �� Padding$ 10q�._��� .+��� $��KẾT QUẢ HỌC TẬP��$��28(�$
��Bold"����#F02A2A$��Center=�$��0,0,0,10q�&   System.Windows.Controls.DataGrid  -     Name$ dgKetQua��   AutoGenerateColumns$ False��   CanUserAddRows$ False��   
IsReadOnly$
 True��   HeadersVisibility$ Column=�$��14(�$	��300��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Mã HP��	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 �� *MaHP+  $ Tên học phần��$	 2* 
 �� *TenHP+  $ Số TC��$	 * 
 �� *
SoTinChi+  $ Lớp��$	 * 
 �� *MaLop+  $
 Kỳ��$	 * 
 �� *MaKi+  $ Giữa kỳ��$	 * 
 �� *
DiemGiuaKi+  $ Cuối kỳ��$	 * 
 �� *
DiemCuoiKi+  $ Tổng kết��$	 * 
 �� *DiemTongKet+  $ Điểm chữ��$	 * 
 �� *	DiemChu+