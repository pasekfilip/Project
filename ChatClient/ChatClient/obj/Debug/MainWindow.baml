   M S B A M L   `   `   `  ����E  AChatClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ChatClient
ChatClient  5   	       ChatClient.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ChatClient     5   	     � Title$  
MainWindow��5   	   $	��600��6   $
��1000��6)   $
��1000��66   $	��600��6F   $
��1000��6V   $	��600��6f   .��5	      � $��0,0,0,1q�6    � RowDefinitions 5
   
   �� 5      $	��48* �6   �� 5      $
��465* �6   �� 5      $	��55* �6    � ColumnDefinitions 5   
   �� 5      -   5         ��Name$ Friends_part��5      �� 5      -   5        $
 Chat��5      $��3* �6-   .+�5   
   �� $
��Left=�6   $��48��6,   $	��Top=�68   $	��248��6P   ���	#FF1D6AC7.+�5      �� -   5         ��Name$ textbox_search_chats��5      $��28��64    �� Left$ 37��6@    �� TextWrapping$
 Wrap=�6Q   
 �� Top$ 10��6e   $	��180��6u   ���	#7F6E6EB2���	#B2ABADB36�   5      �� 5   
   -   5         ��Name$ FriendsCanvas��5      $
��Left=�6(   $	��465��6C   $��1��6P   $	��Top=�6]   $	��248��6u   ���	#FF1D6AC76�   �� 5   
   $
��Left=�6   $��55��6,   $��2��68   $	��Top=�6E   $	��248��6]   ���	#FF1D6AC7.+�5      A� -   5        
�������$��50��5   #   $ 20��6/   $ 2��6@   $��50��6O   6Z   �� 5      ���	#FF1D6AC7$��10��6)   $��35��65   $ 27��6@   $ 22��6Q   	 �� RadiusY$	 5��6a   
 �� RadiusX$
 5��6m   6|   �� 5      ���	#FF1D6AC7$��10��6)   $��35��65   $ 27��6@   $ 22��6Q   $	 5��6a   $
 5��6m    J� RenderTransformOrigin$ 0.5,0.5&�6y   z�5      V� 5      .~�5       �� �� 5!      �� 5"       �� Angle$ 90Q�6*   T� 5#      5$      5&      5'      � 5(   
   $	��100��6   $	��100��6   $��5q�6(   �� 5)   
   -   5        $ Canvasmessages��5)      $��1��6)   $
��Left=�69   $	��465��6T   $��1��6a   $	��Top=�6n   $	��744��6�   �� 5*   
   -   5        $ nazevchatcanvas��5*      $��1��6*   $
��Left=�6:   $��48��6U   $	��Top=�6a   $	��744��6y   .+�5+      �� -   5         ��Name$ 	chat_name��5+      $��Label��6'   $
��Left=�67   $	��Top=�6R   $ 10��6j   $ 12��6{   �� 5,      $��Button��6   $	 659��6&   $ 15��68   $��75��6H   5-      �� 5.   
   -	   5        $ sendmessagecanvas��5.      $��1��6,   $
��Left=�6<   $��55��6W   $��2��6c   $	��Top=�6p   $	��744��6�   .+�5/      �� $
��Left=�6   $��23��61   $
 Wrap=�6=   $��TextBox��6Q   $	��Top=�6`   $	��567��6x   $ 75��6�   $ 18��6�   �� 50      $��Button��6   $
��Left=�6&   $	��Top=�6A   $��38��6Y   $ 19��6d   $ 18��6u   �� 51      $��Button��6   $
��Left=�6&   $	��Top=�6A   $��45��6Y   $	 666��6d   $ 18��6v   52      54      56      