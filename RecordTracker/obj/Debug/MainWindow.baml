   M S B A M L   `   `   `  ����H  DRecordTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:RecordTrackerRecordTracker  5   	       RecordTracker.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:RecordTracker     5   	     � Title$  
MainWindow��5   	   $��380.939��6   $	��425��6-   .��5	      � $��	0,0,38,72q�6   .+�5
   
   �� -   5         ��Name$ btnFindRecords��5
      {�.  $
��Find��6;   $
��Left=�6g   $��131,213,0,0q�6�   $	��Top=�6�   $��75��6�   �� 5   
   -   5         ��Name$ cmbTableName��5      $
��Left=�6S   $��131,104,0,0q�6n   $	��Top=�6�   $	��239��6�   �� 5   
   -   5        $ cmbFieldNames��5      $
��Left=�6*   $��21��6E   $��131,135,0,0q�6Q   $	��Top=�6f   $	��239��6~   �� 5   
   -   5         ��Name$ txtFieldValue��5      $
��Left=�6)   $��28��6D   $��131,168,0,0q�6P    �� TextWrapping$
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��239��6�   �� 5   
   -   5        $ txtConnectionString��5      $
��Left=�6/   $��23��6J   $��	28,34,0,0q�6V   $
 Wrap=�6i   $�� ��6}   $	��Top=�6�   $	��436��6�   �� 5   
   -   5         ��Name$ label��5      $8��2Connection String Override (default in App.Config)��6   $
��Left=�6\   $��28,8,0,0q�6w   $	��Top=�6�   �� 5   
   -   5        $ btnConnectSql��5      $��Connect To SQL��6(   $
��Left=�6]   $��	28,62,0,0q�6x   $	��Top=�6�   $	��104��6�   �� 5   
   -   5        $ label1��5      $��Tables��6    $
��Left=�61   $��
81,104,0,0q�6L   $	��Top=�6`   $��45��6x   �� 5   
   -	   5        $ label2��5      $��Columns��6    $
��Left=�62   $��35��6M   $��
65,135,0,0q�6Y   $	��Top=�6m   $��61��6�   �� 5   
   -
   5        $ label3��5      $��Value of Column��6    $
��Left=�6:   $��
28,170,0,0q�6U   $	��Top=�6i    J� RenderTransformOrigin$ -0.236,0.176&�6�   $	��103��6�   �� 5   
   -   5        $ lblConnectionStatus��5      $��Closed��6-   $
��Left=�6>   $��
158,56,0,0q�6Y   $	��Top=�6m   5      5      