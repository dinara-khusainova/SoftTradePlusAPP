   M S B A M L   `   `   `  ����K  GSoftTradePlusAPP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:SoftTradePlusAPP.ConvertersSoftTradePlusAPP.Converters  5   	   U/clr-namespace:SoftTradePlusAPP.MarkupExtensions!SoftTradePlusAPP.MarkupExtensions  5   	   =#clr-namespace:SoftTradePlusAPP.ViewSoftTradePlusAPP.View  5	   	   ?$clr-namespace:SoftTradePlusAPP.ModelSoftTradePlusAPP.Model  5
   	   !    SoftTradePlusAPP.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @
converters)clr-namespace:SoftTradePlusAPP.Converters     5   	   LmarkupExtensions/clr-namespace:SoftTradePlusAPP.MarkupExtensions     5   	   5local#clr-namespace:SoftTradePlusAPP.View     5	   	   6enums$clr-namespace:SoftTradePlusAPP.Model     5
   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � DataContext 5   	   ��  �� RelativeSource �� *Self+ � 	Resources 5      7  1SoftTradePlusAPP.Converters.StatusToTextConverter   StatusToTextConverter��%   &	          5   
   6+   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   �� $��0��6    �� SelectedItem 6"   �� *SelectedTabItem+.@�5      �� -   5        $��
ManagerTab��5      ��5      �� 5      $��Managers��6     � ContextMenu 5      �� 5      .@�5      m� $
��Edit��6#    m� Command 61   �� *OpenEditItemWnd+m� 5      $��Delete��6#    63   �� *
DeleteItem+5       .��5"      �� -   5        $��ViewAllManagers��5"      ��62   �� *AllManagers+ 5#      �� *SelectedManagerLine+ �� View 5$      �� 5%      .P�5&      �� $
��Name��6-   	 �� DisplayMemberBinding	 6;   �� 
 �� Path$

 Name�5'      5)      5*      �� 5+      -   5        $��	ClientTab��5+      ��5,      �� 5-      $��Clients��6     5/      �� 50      .@�51      m� $
��Edit��6#    61   �� *OpenEditItemWnd+m� 52      $��Delete��6#    63   �� *
DeleteItem+53      .��55      �� -   5        $��ViewAllClients��55      ��61   �� *
AllClients+ 56      �� *SelectedClientLine+ 57      �� 58      .P�59      �� $
��Name��6-   	 6;   �� $

 Name��� 5:      $��Status��6-   	 6=   �� $
 Status��� 5;      $��Manager��6-   	 6>   �� $
 ClientManager.Name��� 5<      $��Purchased Products��6-    �� CellTemplate 5=   "   �� 5>   &   .R�5?   *   �� ��67   �� *ClientProducts+��5@   .   �� 5A   2   .R�5B   6   �� ��6@   �� *Name+5C   3   5E   +   5F   '   5H      5I      5K      5L      �� 5M      -   5        $��
ProductTab��5M      ��5N      �� 5O      $��Products��6     5Q      �� 5R      .@�5S      m� $
��Edit��6#    61   �� *OpenEditItemWnd+m� 5T      $��Delete��6#    63   �� *
DeleteItem+5U      .��5W      �� -   5        $��ViewAllProducts��5W      ��62   �� *AllProducts+ 5X      �� *SelectedProductLine+ 5Y      �� 5Z      .P�5[      �� $
��Name��6-   	 6;   �� $

 Name��� 5\      $��Price��6-   	 6<   �� $
 Price��� 5]      $
��Type��6-   	 6;   �� $

 Type��� 5^      $��Subscription Period��6-   	 6J   �� $
 SubscriptionPeriod�5_      5a      5b      �� 5c      -   5        $��ClientsandMenegersTab��5c      ��5d      �� 5e      $��Clients by Manager��6    .��5g      � .+�5h      ��  �� Orientation$ Vertical=�6!   .+�5i      ��  �� DisplayMemberPath$
 Name��5j       �� SelectedValuePath$ Id��5l      ��5i   #   �� *AllManagers+ 5k      �� *SelectedManager+ �� Mode$ TwoWay=�5l      �� 5m      -   5        $��ViewClientsandMenegers��5m   #   ��6A   �� *ClientsBySelectedManager+ 5n      �� 5o   "   .P�5p   &   �� $
��Name��65   	 6C   �� *Name+�� 5q   &   $��Status��65   	 6E   �� $
 Status�5r   #   5t      5u      5v      5w      �� 5x      -	   5        $��ProductsandClientsTab��5x      ��5y      �� 5z      $��Products by Client��6    .��5|      � .+�5}      �� $ Vertical=�6!   .+�5~      �� $
 Name��5      $ Id��5�      ��5~   #   �� *
AllClients+ 5�      �� *SelectedClient+$ TwoWay=�5�      �� 5�      -
   5        $��ViewProductsandClients��5�   #   ��6A   �� *ProductsBySelectedClient+ 5�      �� 5�   "   .P�5�   &   �� $
��Name��65   	 6C   �� *Name+�� 5�   &   $��Price��65   	 6D   �� $
 Price��� 5�   &   $
��Type��65   	 6C   �� $

 Type��� 5�   &   $��Subscription Period��65   	 6R   �� $
 SubscriptionPeriod�5�   #   5�      5�      5�      5�      �� 5�      -   5        $��StatusandClientsTab��5�      ��5�      �� 5�      $��Clients by Status��6    .��5�      � .+�5�      �� $ Vertical=�6!   .+�5�      �� ��6#   2   ,SoftTradePlusAPP.MarkupExtensions.EnumValues  *M� *enums:ClientStatus++ 5�      �� *SelectedClientStatusFilter+$ TwoWay=���5�      �� 5�   "   .R�5�   &   �� ��60   ��  �� 	Converter# [  5�   #   5�      �� 5�      -   5        $��ViewStatusandClients��5�   #   ��6?   �� *ClientsBySelectedClientStatus+ 5�      �� 5�   "   .P�5�   &   �� $
��Name��65   	 6C   �� $

 Name��� 5�   &   $��Status��65   	 6E   �� $
 Status�5�   #   5�      5�      5�      5�      5�      �� 5�   
   $��1��6   $ 
Horizontal=�6"   $��Right=�5�      .+�5�      �� $��New Manager��6   $	��105��6T   ��6+   �� *OpenAddNewManagerWnd+6T   �� 5�      $��
New Client��6   $	��105��6R   ��6*   �� *OpenAddNewClientWnd+6R   �� 5�      $��New Product��6   $	��105��6T   ��6+   �� *OpenAddNewProductWnd+6T   5�      5�      5�      