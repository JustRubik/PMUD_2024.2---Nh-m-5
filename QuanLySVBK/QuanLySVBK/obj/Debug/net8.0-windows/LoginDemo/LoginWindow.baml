   M S B A M L   `   `   `  ����  	LoginDemo    LoginDemo.LoginWindow   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Aav2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  	LoginDemo��5       � WindowStartupLocation$ CenterScreen=�5	       � WindowStyle$ SingleBorderWindow=�5
       � WindowState$ 	Maximized=�5      
������ .��5      � .+�5   
   �� $.��(Images/background_man_hinh_dang_nhap.jpg��6   $
��Fill=�6B   �� 5   
   ���	#CCF02A2A6   �� 5   
   $	��350��6   $	��440��6   
������� �� CornerRadius$ 10��6=   $��Center=�5      $��Center=�6.    �� Padding$ 20q�6I    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      ._�5      �� .+�5      �� $��Đăng nhập��6   $
��Bold"�6-   $��24(�6?   $��Center=�5      $
��0,10q�69   �� 5      $"��Images/logo_dai_hoc_bkhn.PNG��6   $	��100��6>   $	��100��6J   $��Center=�6W   $
��0,10q�6t   �� 5!      $��Bạn là: ��6   $��12(�6,   $��0,10,0,5q�6:   �� 5"       �� Orientation$ 
Horizontal=�6   $��Center=�66   $��0,0,0,0q�6S   .+�5#      	� -   5         	�Name$ StudentRadio��5#   "   $��
Sinh viên��68   	 	� 	GroupName$
	 Role��6L   $
��10,0q�6]   	� 5$      -   5        $ 
AdminRadio��5$   "   $��Admin��66   $
	 Role��6F   $
��10,0q�6W   	� 5%      -   5        $ TeacherRadio��5%   "   $��Giảng viên��68   $
	 Role��6M   $
��10,0q�6^   5&      �� 5)      $��Tài khoản��6   $��12(�6-   $��0,10,0,0q�6;   ]� 5*      .+�5+      �� $��Images/icon-user.png��6   $��16��6:   $��16��6E   $��0,0,5,0q�6Q   �� 5,      -   5        
 ��Name$
 UsernameBox��5,      $
��Auto��63    � ToolTip$* $Vui lòng nhập email đăng nhập��6@   5-      �� 50      $��Mật khẩu��6   $��12(�6,   $��0,10,0,0q�6:   ]� 51      .+�52      �� $��Images/icon-lock.png��6   $��16��6:   $��16��6E   $��0,0,5,0q�6Q   G� 53      -   5         G�Name$ PasswordBox��53   "   $
��Auto��67   $# Vui lòng nhập mật khẩu��6D   54      �� 57      -   5         ��Name$ ForgotPassword��57      $��Quên mật khẩu?��64   $��10(�6J   $��Right=�6X   $��0,5,0,0q�58      
������� � Cursor$
 Hand��6?   59      �� 5<      -   5         ��Name$ LoginButton��5<      $��ĐĂNG NHẬP��6.   $	��200��6B   $��40��6N   $
��Bold"�5=      ���#9CABF5
�������$��0q�5>      $��0,20,0,0q�6-   $
 Hand��5?   3   ��5@      �� 5A       �� 
TargetType" ��6*   .R�5B      ��  ��Name$ border��6%   #��z��5C   %   $ 20��5D   %   #��z��5E   %   #��z��5F   %   ._�5G   "   �� $��Center=�63   $��Center=�6P   5H       �� Triggers 5I      P� 5J   "    P� Property �@J�IsMouseOver P� Value$
 True��6A   . �5K   &   ��  �� 
TargetName$ border��6-    �� Property � �� �� Value �#7A93F76W   5L   #   P� 5M   "    � ��$
 True��6?   . �5N   &   �� $ border��6-    � �� �#5A75E66W   5O   #   P� 5P   "    � {�$ False��6?   . �5Q   &   �� $ border��6-    � �� �#CCC6W   �� 5R   &    � ��
 �����6C   5S   #   5U      5W      5X      5Y      5Z      5[      