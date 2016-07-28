��C R E A T E   D A T A B A S E   [ c h a r a c t e r _ c r e a t o r ]  
 G O  
 U S E   [ c h a r a c t e r _ c r e a t o r ]  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ c h a r a c t e r s ]         S c r i p t   D a t e :   7 / 2 5 / 2 0 1 6   1 0 : 4 0 : 2 4   A M   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ c h a r a c t e r s ] (  
 	 [ i d ]   [ i n t ]   I D E N T I T Y ( 1 , 1 )   N O T   N U L L ,  
 	 [ n a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ c l a s s _ i d ]   [ i n t ]   N U L L  
 )   O N   [ P R I M A R Y ]  
  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ c l a s s e s ]         S c r i p t   D a t e :   7 / 2 5 / 2 0 1 6   1 0 : 4 0 : 2 4   A M   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ c l a s s e s ] (  
 	 [ i d ]   [ i n t ]   I D E N T I T Y ( 1 , 1 )   N O T   N U L L ,  
 	 [ n a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L  
 )   O N   [ P R I M A R Y ]  
  
 G O  
 I N S E R T   I N T O   c l a s s e s   ( n a m e )   V A L U E S   ( ' B u s i n e s s   M a n ' ) ;  
 I N S E R T   I N T O   c l a s s e s   ( n a m e )   V A L U E S   ( ' S p a c e   D r a g o n ' ) ;  
 I N S E R T   I N T O   c l a s s e s   ( n a m e )   V A L U E S   ( ' A l i e n   C y b o r g ' ) ;  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ c l a s s e s _ i t e m s ]         S c r i p t   D a t e :   7 / 2 5 / 2 0 1 6   1 0 : 4 0 : 2 4   A M   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ c l a s s e s _ i t e m s ] (  
 	 [ i d ]   [ i n t ]   I D E N T I T Y ( 1 , 1 )   N O T   N U L L ,  
 	 [ c l a s s _ i d ]   [ i n t ]   N U L L ,  
 	 [ i t e m _ i d ]   [ i n t ]   N U L L  
 )   O N   [ P R I M A R Y ]  
  
 G O  
 I N S E R T   I N T O   c l a s s e s _ i t e m s   ( c l a s s _ i d ,   i t e m _ i d )   V A L U E S   ( 1 , 1 ) ;  
 I N S E R T   I N T O   c l a s s e s _ i t e m s   ( c l a s s _ i d ,   i t e m _ i d )   V A L U E S   ( 1 , 2 ) ;  
 I N S E R T   I N T O   c l a s s e s _ i t e m s   ( c l a s s _ i d ,   i t e m _ i d )   V A L U E S   ( 1 , 3 ) ;  
 I N S E R T   I N T O   c l a s s e s _ i t e m s   ( c l a s s _ i d ,   i t e m _ i d )   V A L U E S   ( 1 , 4 ) ;  
 I N S E R T   I N T O   c l a s s e s _ i t e m s   ( c l a s s _ i d ,   i t e m _ i d )   V A L U E S   ( 1 , 5 ) ;  
 I N S E R T   I N T O   c l a s s e s _ i t e m s   ( c l a s s _ i d ,   i t e m _ i d )   V A L U E S   ( 1 , 6 ) ;  
 G O  
 I N S E R T   I N T O   c l a s s e s _ i t e m s   ( c l a s s _ i d ,   i t e m _ i d )   V A L U E S   ( 2 , 7 ) ;  
 I N S E R T   I N T O   c l a s s e s _ i t e m s   ( c l a s s _ i d ,   i t e m _ i d )   V A L U E S   ( 2 , 8 ) ;  
 I N S E R T   I N T O   c l a s s e s _ i t e m s   ( c l a s s _ i d ,   i t e m _ i d )   V A L U E S   ( 2 , 9 ) ;  
 I N S E R T   I N T O   c l a s s e s _ i t e m s   ( c l a s s _ i d ,   i t e m _ i d )   V A L U E S   ( 2 , 1 0 ) ;  
 I N S E R T   I N T O   c l a s s e s _ i t e m s   ( c l a s s _ i d ,   i t e m _ i d )   V A L U E S   ( 2 , 1 1 ) ;  
 I N S E R T   I N T O   c l a s s e s _ i t e m s   ( c l a s s _ i d ,   i t e m _ i d )   V A L U E S   ( 2 , 1 2 ) ;  
 G O  
 I N S E R T   I N T O   c l a s s e s _ i t e m s   ( c l a s s _ i d ,   i t e m _ i d )   V A L U E S   ( 3 , 1 3 ) ;  
 I N S E R T   I N T O   c l a s s e s _ i t e m s   ( c l a s s _ i d ,   i t e m _ i d )   V A L U E S   ( 3 , 1 4 ) ;  
 I N S E R T   I N T O   c l a s s e s _ i t e m s   ( c l a s s _ i d ,   i t e m _ i d )   V A L U E S   ( 3 , 1 5 ) ;  
 I N S E R T   I N T O   c l a s s e s _ i t e m s   ( c l a s s _ i d ,   i t e m _ i d )   V A L U E S   ( 3 , 1 6 ) ;  
 I N S E R T   I N T O   c l a s s e s _ i t e m s   ( c l a s s _ i d ,   i t e m _ i d )   V A L U E S   ( 3 , 1 7 ) ;  
 I N S E R T   I N T O   c l a s s e s _ i t e m s   ( c l a s s _ i d ,   i t e m _ i d )   V A L U E S   ( 3 , 1 8 ) ;  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ i t e m s ]         S c r i p t   D a t e :   7 / 2 5 / 2 0 1 6   1 0 : 4 0 : 2 4   A M   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ i t e m s ] (  
 	 [ i d ]   [ i n t ]   I D E N T I T Y ( 1 , 1 )   N O T   N U L L ,  
 	 [ n a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ t y p e _ i d ]   i n t  
 )   O N   [ P R I M A R Y ]  
  
 G O  
 I N S E R T   I N T O   i t e m s   ( n a m e ,   t y p e _ i d )   V A L U E S   ( ' B r i e f   C a s e ' ,   1 ) ;  
 I N S E R T   I N T O   i t e m s   ( n a m e ,   t y p e _ i d )   V A L U E S   ( ' S p e c t a c l e s ' ,   2 ) ;  
 I N S E R T   I N T O   i t e m s   ( n a m e ,   t y p e _ i d )   V A L U E S   ( ' D a p p e r   J a c k e t ' ,   2 ) ;  
 I N S E R T   I N T O   i t e m s   ( n a m e ,   t y p e _ i d )   V A L U E S   ( ' D a p p e r   C u f f s ' ,   2 ) ;  
 I N S E R T   I N T O   i t e m s   ( n a m e ,   t y p e _ i d )   V A L U E S   ( ' D a p p e r   P a n t s ' ,   2 ) ;  
 I N S E R T   I N T O   i t e m s   ( n a m e ,   t y p e _ i d )   V A L U E S   ( ' U m b r e l l a ' ,   3 ) ;  
 G O  
 I N S E R T   I N T O   i t e m s   ( n a m e ,   t y p e _ i d )   V A L U E S   ( ' D r a g o n   B r e a t h ' ,   1 ) ;  
 I N S E R T   I N T O   i t e m s   ( n a m e ,   t y p e _ i d )   V A L U E S   ( ' D r a g o n   H e a d ' ,   2 ) ;  
 I N S E R T   I N T O   i t e m s   ( n a m e ,   t y p e _ i d )   V A L U E S   ( ' S p a c e   S h i r t ' ,   2 ) ;  
 I N S E R T   I N T O   i t e m s   ( n a m e ,   t y p e _ i d )   V A L U E S   ( ' D r a g o n   A r m s ' ,   2 ) ;  
 I N S E R T   I N T O   i t e m s   ( n a m e ,   t y p e _ i d )   V A L U E S   ( ' S p a c e   P a n t s ' ,   2 ) ;  
 I N S E R T   I N T O   i t e m s   ( n a m e ,   t y p e _ i d )   V A L U E S   ( ' S p a c e   T h i n g ' ,   3 ) ;  
 G O  
 I N S E R T   I N T O   i t e m s   ( n a m e ,   t y p e _ i d )   V A L U E S   ( ' L a s e r   G u n ' ,   1 ) ;  
 I N S E R T   I N T O   i t e m s   ( n a m e ,   t y p e _ i d )   V A L U E S   ( ' A l i e n   H e a d ' ,   2 ) ;  
 I N S E R T   I N T O   i t e m s   ( n a m e ,   t y p e _ i d )   V A L U E S   ( ' R o b o t   A r m s ' ,   2 ) ;  
 I N S E R T   I N T O   i t e m s   ( n a m e ,   t y p e _ i d )   V A L U E S   ( ' A l i e n   C h e s t ' ,   2 ) ;  
 I N S E R T   I N T O   i t e m s   ( n a m e ,   t y p e _ i d )   V A L U E S   ( ' R o b o t   L e g s ' ,   2 ) ;  
 I N S E R T   I N T O   i t e m s   ( n a m e ,   t y p e _ i d )   V A L U E S   ( ' F a b i o   H a i r ' ,   3 ) ;  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ i t e m _ t y p e s ] (  
 	 [ i d ]   [ i n t ]   I D E N T I T Y ( 1 , 1 ) ,  
 	 [ n a m e ]   V A R C H A R ( 2 5 5 )  
 )   O N   [ P R I M A R Y ]  
  
 G O  
 I N S E R T   I N T O   i t e m _ t y p e s   ( n a m e )   V A L U E S   ( ' W e a p o n ' ) ;  
 I N S E R T   I N T O   i t e m _ t y p e s   ( n a m e )   V A L U E S   ( ' A r m o r ' ) ;  
 I N S E R T   I N T O   i t e m _ t y p e s   ( n a m e )   V A L U E S   ( ' S p e c i a l ' ) ;  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 
