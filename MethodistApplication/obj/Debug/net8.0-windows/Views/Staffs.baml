   M S B A M L   `   `   `  ����O  KMethodistApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:MethodistApplication.ViewsMethodistApplication.Views  5      '    !MethodistApplication.Views.Staffs   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:MethodistApplication.Views     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $	��16* �6   �� 5      $	��19* �6   �� 5      $	��15* �6    � RowDefinitions 5   
   �� 5      $	��31* �6   �� 5      $
��194* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
StaffTable��5      $��1��6'   $��3��64      
IsReadOnly$
 True��6H   �� 5   
   -   5        $��AddStaffButton��5      $��+Сотрудник��6'      ButtonSettings#���   6=   $��Stretch=�6f   $��Stretch=�6�   $��2��6�   �� 5   
   -   5        $��SearchField��5   "   $��0��6   $��0��67   $��10,10,10,10q�6D   $��Center=�6Y     placeHolder#��[ 6}   
 � Tag$ 
Поиск��6�   5      5      