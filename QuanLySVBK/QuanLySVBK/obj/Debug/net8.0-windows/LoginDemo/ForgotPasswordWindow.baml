   M S B A M L   `   `   `  ����  	LoginDemo$    LoginDemo.ForgotPasswordWindow   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Aav2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  	LoginDemo��5       � WindowStartupLocation$ CenterScreen=�5	       � WindowStyle$ SingleBorderWindow=�5
       � WindowState$ 	Maximized=�5      
������ .��5      � .+�5   
   �� $.��(Images/background_man_hinh_dang_nhap.jpg��6   $
��Fill=�6B   �� 5   
   ���	#CCF02A2A6   �� 5   
   $	��350��6   $	��250��6   
������� �� CornerRadius$ 10��6=   $��Center=�5      $��Center=�6.    �� Padding$ 20q�6I    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      ._�5      �� .+�5      � $��0q�6   .+�5      �� $"��Vui lòng nhập email để��6    $
��Bold"�5      $��24(�5      $��Center=�5      $
��Wrap=�5      5       � 5"      $��0,0,0,30q�6   .+�5#      �� $��lấy lại mật khẩu��6    $
��Bold"�5$      $��24(�5%      $��Center=�5&      $
��Wrap=�5'      5(      ]� 5+      .+�5,      �� $��Images/icon-user.png��6   $��16��6:   $��16��6E   $��0,0,5,0q�6Q   �� 5-      -   5         ��Name$ EmailBox��5-      $
��Auto��60    � ToolTip$ Nhập email của bạn��6=   5.      �� 51      -   5        	 ��Name$	 
SendButton��51      $��GỬI��6-   $	��200��6;   $��40��6G   $
��Bold"�52      ���#9CABF5
�������$��0q�53      $��0,20,0,0q�6-   
 � Cursor$

 Hand��54   2   ��55      �� 56       �� 
TargetType" ��6*   .R�57      ��  ��Name$ border��6%   #��z��58   %   $ 20��59   %   #��z��5:   %   #��z��5;   %   ._�5<   "   �� $��Center=�63   $��Center=�6P   5=       �� Triggers 5>      P� 5?   "    P� Property �@J�IsMouseOver P� Value$
 True��6A   . �5@   &   ��  �� 
TargetName$ border��6-    �� Property � �� �� Value �#7A93F76W   5A   #   P� 5B   "    � ��$
 True��6?   . �5C   &   �� $ border��6-    � �� �#5A75E66W   5D   #   P� 5E   "    � {�$ False��6?   . �5F   &   �� $ border��6-    � �� �#CCC6W   �� 5G   &    � ��
 �����6C   5H   #   5J      5L      5M      5N      5O      5P      