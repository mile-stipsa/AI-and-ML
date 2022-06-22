;;-----------------------------------------------------------------------------------------------Faza 1--------------------------------------------------------------------------------------------------

(defun pokreniigru()
   (setq grafX '())
   (setq grafO '())

   (setq listaX1 '())
   (setq listaX2'())
   (setq listaX3 '())
   (setq listaX4'())
   (setq listaX5 '())
   (setq listaX6 '())
   (setq coske1 '())

   (setq listaO1 '())
   (setq listaO2'())
   (setq listaO3 '())
   (setq listaO4'())
   (setq listaO5 '())
   (setq listaO6 '())
   (setq svaMogucaX '())
   (setq svaMogucaO '())

   (princ "Unesite velicinu table: ")
   (setq velicina (read))
   (loop while (or (> velicina 12) (< velicina 6))
      do
         (princ "Velicina table mora biti u opsegu 6-12! ")
         (terpri)
         (princ "Unesite velicinu table ponovo: ")
         (setq velicina (read))
   )
   (format t "Uneta velicina je ~D~%" velicina)
   (princ "Prvi igra racunar(0)/covek(1): ")
   (setq igraPrvi (read))

   (loop while (and (not (equalp igraPrvi '0)) (not (equalp igraPrvi '1)))
      do
         (princ "Unesite ispravne vrednosti! ")
         (terpri)
         (princ "Prvi igra racunar(0)/covek(1): ")
         (setq igraPrvi (read))
   )

   (setq XO T)
   (setq ta nil)
   
   (cond 
      ((equalp igraPrvi '0) (setq XO (not XO)))
   )


   
   (setq pocetnostanje (spoji velicina))
   (format t "Pocetno stanje: ~%")
   (setq kraj T)

   (loop while kraj
      do
      (iscrtaj pocetnostanje)
      (if (not XO)
         (setq pocetnostanje (car(minimax pocetnostanje 2 -10000 10000 XO)))
      )
      (if (not XO) (vratiPotez pocetnostanje -1 0))
      (if XO
         (setq svaMogucaX (moguca pocetnostanje 0 0 XO))
         (setq svaMogucaO (moguca pocetnostanje 0 0 XO))
      )
      (terpri)
      (cond
      (XO (princ "Unesite potez: ") (setq slovo (read))(setq polje(read))
      (loop while (or(not(validan slovo polje)) (not (validan1 slovo polje pocetnostanje)))  do (format t "Nevalidan potez~%Unesite potez ponovo:") (setq slovo (read))(setq polje(read)) )
      (setq pocetnostanje (potez pocetnostanje slovo polje XO))
      (napraviGraf slovo polje XO)
      (setq coske (odigraneCoske grafX)))
      )
      (listeIvica slovo polje XO)
      (if XO (if (or(most grafX coske)(= 2 (fork grafX (velikaListaIvica XO))) (prsten grafX (cvoroviGrafa1 grafX) (list slovo polje))) (setq kraj nil)) (if (or (most grafO coske1)(= 2 (fork grafO (velikaListaIvica XO))) (prsten grafO (cvoroviGrafa1 grafO) (list slovo polje))) (setq kraj nil)))
      (setq XO (not XO))

      (cond ((null (moguca pocetnostanje 0 0 XO)) (setq kraj nil) (setq ta 't)))
   )
   (iscrtaj pocetnostanje)

   (cond 
      (ta (format t "~%Nereseno"))
      ((not XO) (format t "~%Pobednik je igrac X"))
      (XO (format t "~%Pobednik je igrac O"))
   )
)


;;iscrtavanje table -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


(defun prvired (velicina)   
	(setq brojac velicina)
	(setq brojac1 (- velicina 1))
	(setq brojac2 velicina)
	(setq pomlista '())
	(setq brojac3 0)
	(setq brojacSlova 0)

   (loop for a from 1 to (+ (* 2 velicina) (* 2 (- velicina 1)))
      do
         (cond ((< a (1+ brojac)) (setq pomlista (append pomlista (list '*))))
			      ((and (> a brojac) (< a (+ brojac brojac1 2))) 
	            (setq pomlista (append pomlista (append (list brojac3) (list '*))))
			      (setq brojac3 (1+ brojac3)))
			      ((> a (+ brojac brojac1 brojac2)) (setq pomlista (append pomlista (list '*))))
         )
   )
)
			  
(defun gornja (velicina)
   (setq slova '(A B C D E F G H I J K L M N P R S T U V W Y Z))
	(setq pomlista1 '())
	(setq pomlista2 '())
	(setq brojacSlova 0)		
   (setq brojac velicina)
   (setq brojac1 (1- velicina))	 
	(setq brojac2 (* 2 velicina))
	(setq brojac3 '0)
	  
   (loop for a from 1 to (- velicina 1)
	   do 
         (setq pomlista1 (append pomlista1 (list (nth brojacSlova slova))))

	      (loop for a from 1 to (- brojac 2)
	         do
               (setq pomlista1 (append pomlista1 (list '*)))
         )

	      (loop for b from 1 to brojac2
	         do
               (if(oddp b)(setq pomlista1 (append pomlista1 (list '*)))(setq pomlista1 (append pomlista1 (list '-))))
         )

	      (setq pomlista1 (append pomlista1 (list (+ velicina brojac3))))
	      (setq pomlista2 (append pomlista2 pomlista1))(setq pomlista1 '()) (setq brojac (- brojac 1))(setq brojac3 (1+ brojac3))
	      (setq brojacSlova (1+ brojacSlova))(setq brojac2 (+ brojac2 2))
   )
)
							 
(defun sredina (velicina)
   (setq slova '(A B C D E F G H I J K L M N P R S T U V W Y Z))
   (setq pomlista3 '())
   (setq slovo (nth (1- velicina) slova))
    
   (setq pomlista3 (append pomlista3 (list slovo)))
   (loop for a from 1 to (+ (* 2 velicina) (* 2 (- velicina 1)))
      do
         (if(oddp a)(setq pomlista3 (append pomlista3 (list '-))) (setq pomlista3 (append pomlista3 (list '*))))
   )
)  

(defun donja (velicina)
   (setq slova '(A B C D E F G H I J K L M N P R S T U V W Y Z))
	(setq pomlista4 '())
	(setq pomlista5 '())
	(setq brojacSlova velicina)		
   (setq brojac velicina)
   (setq brojac1 '0)	 
	(setq brojac2 (+ (* 3 velicina) (- velicina 3)))
	(setq brojac3 '0)
	  
   (loop for a from 1 to (- velicina 1)
	   do 
         (setq pomlista4 (append pomlista4 (list (nth brojacSlova slova))))

	      (loop for a from 1 to brojac1
	         do
            (setq pomlista4 (append pomlista4 (list '*)))
         )

	      (loop for a from 1 to brojac2
	         do
            (if(oddp a)(setq pomlista4 (append pomlista4 (list '*)))(setq pomlista4 (append pomlista4 (list '-))))
         )

	      (setq pomlista5 (append pomlista5 pomlista4))(setq pomlista4 '()) (setq brojac (+ brojac 1))(setq brojac3 (1- brojac3))
	      (setq brojacSlova (1+ brojacSlova))(setq brojac2 (- brojac2 2))(setq brojac1 (1+ brojac1))
   )
)
	
(defun spoji(velicina)
   (prvired velicina) 
   (gornja velicina) 
   (sredina velicina) 
   (donja velicina)
   
   (append pomlista (append pomlista2 (append pomlista3 pomlista5)))
)
 

(defun iscrtaj(lista)
   (cond 
      ((null lista) nil)
      ((and (equal '* (car lista)) (or (equal 'A (cadr lista)) (equal 'B (cadr lista)) (equal 'C (cadr lista))
      (equal 'D (cadr lista))(equal 'E (cadr lista))(equal 'F (cadr lista))(equal 'G (cadr lista))(equal 'H (cadr lista))
      (equal 'I (cadr lista))(equal 'J (cadr lista))(equal 'K (cadr lista))(equal 'L (cadr lista))(equal 'M (cadr lista))(equal 'N (cadr lista))(equal 'P (cadr lista))(equal 'R (cadr lista))(equal 'S (cadr lista))(equal 'T (cadr lista))(equal 'U (cadr lista))(equal 'V (cadr lista))(equal 'W (cadr lista))(equal 'Y (cadr lista))(equal 'Z (cadr lista)))) 
      (format t "~%") (iscrtaj (cdr lista)))
         
      ((equal '* (car lista)) (format t " ") (iscrtaj (cdr lista)))
      ((or (equal 'A (cadr lista)) (equal 'B (cadr lista))(equal 'C (cadr lista))(equal 'D (cadr lista))
      (equal 'E (cadr lista))(equal 'F (cadr lista))(equal 'G (cadr lista))(equal 'H (cadr lista))(equal 'I (cadr lista))
      (equal 'J (cadr lista))(equal 'K (cadr lista))(equal 'L (cadr lista))(equal 'M (cadr lista))(equal 'N (cadr lista))(equal 'P (cadr lista))(equal 'R (cadr lista))(equal 'S (cadr lista))(equal 'T (cadr lista))(equal 'U (cadr lista))(equal 'V (cadr lista))(equal 'W (cadr lista))(equal 'Y (cadr lista))(equal 'Z (cadr lista)))
      (format t "~S~%" (car lista))(iscrtaj (cdr lista)))
      (t (format t "~S" (car lista))(iscrtaj (cdr lista)))
   )
)

;;odigravanje poteza -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

(defun potez (lista slovo broj XO)
   (cond 
      ((null lista) nil)
      ((equal (car lista) slovo) (if (> (indeks slovo slova) (- velicina 1))(append (list (car lista)) (potez1 (cdr lista) (- (- broj  (- (indeks slovo slova) velicina)) 1) XO) ) (append (list (car lista)) (potez1 (cdr lista) broj XO))))
      (t (cons (car lista) (potez (cdr lista) slovo broj XO)))
   )
)
	  
(defun potez1 (lista broj XO)
   (cond 
      ((null lista) nil)
      ((and (= broj 0) (equal (car lista) '-)) (if XO(append (list 'x) (cdr lista)) (append (list 'o) (cdr lista))))
      ((or (equal (car lista) '-) (equal (car lista) 'x) (equal (car lista) 'o)) (cons (car lista) (potez1 (cdr lista) (1- broj) XO)))
	   (t (cons (car lista) (potez1 (cdr lista) broj XO)))
   )
)

(defun indeks (el lista)
   (cond
      ((null lista) -1)
      ((equalp el (car lista)) (+ 0 0))
      (t(1+ (indeks el (cdr lista))))
   )
)


(defun validan (slovo broj)
   (cond
      ((< broj 0) nil)
      ((> (indeks slovo slova) (-(* 2 velicina) 2)) nil)
      ((and(= (indeks slovo slova) (1- velicina)) (>= broj 0) (< broj (- (* 2 velicina) 1)))'T)
      ((and(< (indeks slovo slova) (1- velicina)) (>= broj 0) (< broj (+(indeks slovo slova) velicina))) 'T)
      ((and(> (indeks slovo slova) (1- velicina)) (>= (-(* 2 velicina) 2) broj) (> broj (-(indeks slovo slova) velicina))) 'T)
   )
)

(defun validan1 (slovo broj pocetnostanje)
   (cond
      ((equal slovo (car pocetnostanje))(if (> (indeks slovo slova) (- velicina 1)) (validan2 (- (- broj  (- (indeks slovo slova) velicina)) 1) (cdr pocetnostanje)) (validan2 broj (cdr pocetnostanje))))
      (t (validan1 slovo broj (cdr pocetnostanje)))
   )
)

(defun validan2 (broj pocetnostanje)
   (cond
      ((and(equalp broj '0 ) (not(equalp (car pocetnostanje) '*))) (if (or (equalp (car pocetnostanje) 'x) (equalp (car pocetnostanje) 'o)) nil 'T))
      ((and (or (equal (car pocetnostanje) 'x) (equal (car pocetnostanje) 'o) (equal (car pocetnostanje) '-) ) (> broj '0)) (validan2 (1- broj) (cdr pocetnostanje) ))
      (t (validan2 broj (cdr pocetnostanje)))
   )
)

;;-----------------------------------------------------------------------------------------Faza 2------------------------------------------------------------------------------------------------------------


;;formiranje i obilazak grafa --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


(defun dodaj (potomci obradjeni)
   (cond 
      ((null potomci) '())            
      ((member (car potomci) obradjeni) (dodaj (cdr potomci) obradjeni))              
      (t (cons (car potomci) (dodaj (cdr potomci) obradjeni)))
   )
) 

(defun dodavanje (graf cvor potomci roditelji)
   (dodaj_veze (dodaj_cvor graf cvor potomci) cvor roditelji)
) 

(defun dodaj_cvor (graf cvor potomci)
  (cond 
      ((null graf) (list (cons cvor (list potomci))))
      ((equalp cvor (caar graf))(cons (list (caar graf) (append (cadar graf)(dodaj potomci (cadar graf)))) (cdr graf)))
      (t (cons (car graf) (dodaj_cvor (cdr graf) cvor potomci)))
  )
) 

(defun dodaj_veze (graf cvor roditelji)
   (cond 
      ((null roditelji) graf)
      (t (dodaj_veze (dodaj_pot graf (car roditelji) cvor) cvor (cdr roditelji)))
   )
) 

(defun dodaj_pot (graf cvor pot) 
	(cond 
      ((null graf) graf)
	   ((equalp cvor (caar graf)) (cons (list (caar graf) (append (cadar graf) (dodaj (list pot) (cadar graf)))) (cdr graf)))
	   (t (cons (car graf) (dodaj_pot (cdr graf) cvor pot)))
   )
)

(defun susedi1 (slovo broj)
   (setq susedni '())
      (cond
         ((not (equal (indeks slovo slova) 0))
            (setq susedni (append susedni  (list(cons (nth (1- (indeks slovo slova)) slova) (list(1- broj))))))
            (setq susedni (append susedni (list(cons (nth (1- (indeks slovo slova)) slova) (list broj)))))
         )
      )
      (setq susedni (append susedni (list(cons (nth (indeks slovo slova) slova) (list (1- broj))))))
      (setq susedni (append susedni (list(cons (nth (indeks slovo slova) slova) (list(1+ broj))))))

      (cond
         ((<= (indeks slovo slova) (- (* 2 velicina) 1))
            (setq susedni (append susedni (list(cons (nth (1+ (indeks slovo slova)) slova) (list(1+ broj))))))
            (setq susedni (append susedni (list(cons (nth (1+ (indeks slovo slova)) slova) (list broj)))))
         )
      )
)


(defun susedi2 (lista)
   (cond
      ((null lista) '())
      ((not (validan (caar lista) (cadar lista))) (remove (car lista) lista) (susedi2 (cdr lista)))
      (t (cons (car lista) (susedi2 (cdr lista)) ))
   )

)

(defun susedi (slovo broj)
   (susedi1 slovo broj)
   (setq susedni1 (susedi2 susedni))
)


(defun napraviGraf (slovo broj XO)
   (susedi slovo broj)
   (cond 
      (( equal XO 't) 
         (cvoroviGrafa grafX)
         (if (null grafX) (setq grafX(dodavanje grafX (list slovo broj) '() '() )) (setq grafX(dodavanje grafX (list slovo broj) (susediElementa susedni1 cvorovi) (susediElementa susedni1 cvorovi)) ))
      )
       ((not( equal XO 't))
         (cvoroviGrafa grafO)
         (if (null grafO) (setq grafO(dodavanje grafO (list slovo broj) '() '() )) (setq grafO(dodavanje grafO (list slovo broj) (susediElementa susedni1 cvorovi) (susediElementa susedni1 cvorovi)) ))
      )
   )

)

(defun cvoroviGrafa1(graf)
   (cond ((null graf) nil)
         (t (cons (caar graf) (cvoroviGrafa (cdr graf)))))
)

(defun cvoroviGrafa (graf)
   (setq cvorovi (cvoroviGrafa1 graf))
)

(defun ispitajCvorove (cvor lista)
   (cond
      ((null lista) '())
      ((equal cvor (car lista)) 't)
      (t (ispitajCvorove cvor (cdr lista)) )

   )
)

(defun susediElementa (sus cvorov)
   (cond
      ((or (null sus) (null cvorov)) '())
      ((ispitajCvorove (car sus) cvorov) (cons (car sus) (susediElementa (cdr sus) cvorovi)))
      (t (susediElementa (cdr sus) cvorovi))
   )
)

(defun nadji-put (graf l cilj cvorovi)
	(cond  
      ((null l)  '())
	   ((equal (car l) cilj)  (list cilj))
	   (t  (let* ((cvorovi1 (append cvorovi (list (car l))))
	             (potomci1 (dodaj-potomke graf (car l) (append (cdr l) cvorovi1)))
	             (l1 (append potomci1 (cdr l))) 
	             (nadjeni-put (nadji-put graf l1 cilj cvorovi1)))
	   (cond ((null nadjeni-put)  '()) 
	   ((obradjen (car nadjeni-put) potomci1)  (cons (car l) nadjeni-put))
	   (t  nadjeni-put))))
   )
) 


(defun obradjen (element lista)
   (cond 
      ((null lista) nil)
      ((equal element (car lista)) t)
      (:else (obradjen element (cdr lista)))
   )
)  

(defun dodaj-potomke (graf cvor cvorovi)
  (cond 
      ((null graf) '())
      ((equal (caar graf) cvor) (novi-cvorovi (cadar graf) cvorovi))
      (t(dodaj-potomke (cdr graf) cvor cvorovi))
   )
)

(defun novi-cvorovi (potomci cvorovi)
  (cond 
      ((null potomci) '())
      ((obradjen (car potomci) cvorovi) (novi-cvorovi (cdr potomci) cvorovi))
      (t(cons (car potomci) (novi-cvorovi (cdr potomci) cvorovi)))
   )
)

;;ispitivanje zavrsetka igre-most-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

(defun cose(slovo broj)
   (cond 
      ((and (= broj 0) (= (indeks slovo slova ) 0)) 't)
      ((and (= broj (1- velicina)) (= (indeks slovo slova ) 0)) 't)
      ((and (= broj '0) (= (indeks slovo slova ) (1- velicina))) 't)
      ((and (= broj  (- (* 2 velicina) 2)) (= (indeks slovo slova ) (1- velicina))) 't)
      ((and (= broj (1- velicina)) (= (indeks slovo slova ) (-(* 2 velicina) 2))) 't)
      ((and (= broj (- (* 2 velicina) 2)) (= (indeks slovo slova ) (- (* 2 velicina) 2))) 't)
   )
)

(defun odigraneCoske (graf)
   (cond
      ((null graf) '())
      ((cose (caaar graf) (cadaar graf)) (cons (caar graf) (odigraneCoske (cdr graf))))
      (t (odigraneCoske (cdr graf)))
   )

)

(defun most (graf lista)
   (cond
      ((null lista) '())
      ((most1 graf (car lista) (cdr lista)) 't)
      (t (most graf (cdr lista)))  
   )
)

(defun most1 (graf coska lista)
   (cond
      ((null lista) '())
      ((nadji-put graf  (list coska) (car lista) '()) 't)
      (t (most1 graf coska (cdr lista)))
   )
)

;;ispitivanje zavrsetka igre-vila -------------------------------------------------------------------------------------------------------------------------------------------------------------------------

(defun listeIvica (slovo broj XO)
   (if XO
      (cond
         ((and (= (indeks slovo slova) 0) (and (> broj 0) (< broj (1- velicina)))) (setq listaX1 (cons (list slovo broj) listaX1)))
         ((and (= broj 0) (and (> (indeks slovo slova) 0) (< (indeks slovo slova) (1- velicina)))) (setq listaX2 (cons (list slovo broj) listaX2)))
         ((and (and (> (indeks slovo slova) 0) (< (indeks slovo slova) (1- velicina)) (= broj (+ (indeks slovo slova) (1- velicina))))) (setq listaX3 (cons (list slovo broj) listaX3)))
         ((and (and (> (indeks slovo slova) (1- velicina)) (< (indeks slovo slova) (- (* 2 velicina) 2))) (= broj (- (indeks slovo slova) (1- velicina)))) (setq listaX4 (cons (list slovo broj) listaX4)))
         ((and (= broj (- (* 2 velicina) 2))(and (> (indeks slovo slova) (1- velicina)) (< (indeks slovo slova) (- (* 2 velicina) 2))) ) (setq listaX5 (cons (list slovo broj) listaX5)))
         ((and (= (indeks slovo slova) (- (* 2 velicina) 2)) (and (> broj (1- velicina)) (< broj (- (* 2 velicina) 2)))) (setq listaX6 (cons (list slovo broj) listaX6)))
      )
      (cond
         ((and (= (indeks slovo slova) 0) (and (> broj 0) (< broj (1- velicina)))) (setq listaO1 (cons (list slovo broj) listaO1)))
         ((and (= broj 0) (and (> (indeks slovo slova) 0) (< (indeks slovo slova) (1- velicina)))) (setq listaO2 (cons (list slovo broj) listaO2)))
         ((and (and (> (indeks slovo slova) 0) (< (indeks slovo slova) (1- velicina)) (= broj (+ (indeks slovo slova) (1- velicina))))) (setq listaO3 (cons (list slovo broj) listaO3)))
         ((and (and (> (indeks slovo slova) (1- velicina)) (< (indeks slovo slova) (- (* 2 velicina) 2))) (= broj (- (indeks slovo slova) (1- velicina)))) (setq listaO4 (cons (list slovo broj) listaO4)))
         ((and (= broj (- (* 2 velicina) 2))(and (> (indeks slovo slova) (1- velicina)) (< (indeks slovo slova) (- (* 2 velicina) 2))) ) (setq listaO5 (cons (list slovo broj) listaO5)))
         ((and (= (indeks slovo slova) (- (* 2 velicina) 2)) (and (> broj (1- velicina)) (< broj (- (* 2 velicina) 2)))) (setq listaO6 (cons (list slovo broj) listaO6)))
      )
   )

)

(defun velikaListaIvica (XO)
   (if XO 
      (cons listaX1 (cons listaX2 (cons listaX3 (cons listaX4 (cons listaX5 (list listaX6))))))
      (cons listaO1 (cons listaO2 (cons listaO3 (cons listaO4 (cons listaO5 (list listaO6))))))
   )
)

(defun fork1 (graf el lista2)
   (cond
      ((null lista2) '())
      ((nadji-put graf (list el) (car lista2) '()) 't)
      (t (fork1 graf el (cdr lista2)))
   )
)

(defun fork2 (graf lista1 lista2)
   (cond 
      ((or (null lista1) (null lista2)) '())
      ((fork1 graf (car lista1) lista2) 't)
      (t  (fork2 graf (cdr lista1 ) lista2))
   )
)

(defun fork3 (graf lista)
   (cond
      ((equal (list(car lista)) lista) '())
      ((fork2 graf (car lista) (cadr lista)) 't)
      (t (fork3 graf (cons (car lista) (cddr lista))))
   )
)

(defun fork(graf lista)
   (cond 
      ((null lista) 0)
      ((fork3 graf lista) (+ 1 (fork graf (cdr lista))))
      (t (fork graf (cdr lista)))
   )
)

;;odredjivanje zavrsetka igre-prsten -------------------------------------------------------------------------------------------------------------------------------------------------------------------------

(defun disjunktniPut (graf start cilj)
  (cond 
      ((null graf) 0)
      (:else (let* ((put1 (nadji-put graf start cilj '()))
                    (graf1 (ocisti graf (cdr (reverse (cdr put1))))))
               (cond ((null put1) 0)
               (:else (1+ (disjunktniPut graf1 start cilj)))
               )
            )
      )
   )
)

(defun ocisti (graf lista)
   (cond 
      ((null graf) '())
      ((ocisti1 (caar graf) lista) (ocisti (cdr graf) lista))
      (:else (cons (car graf) (ocisti (cdr graf) lista)))
   )
)
		  
(defun ocisti1 (element lista)
   (cond 
      ((null lista) nil)
      ((equal element (car lista)) t)
	   (t (ocisti1 element (cdr lista)))
   )
)

(defun prsten (graf cvoroviOD odigraniPotez)
   (cond
      ((null cvoroviOD) '())
      ((testSused (car cvoroviOD) odigraniPotez) (prsten graf (cdr cvoroviOD) odigraniPotez))
      ((and(= (length (disjunktniPut1 graf (car cvoroviOD) odigraniPotez)) 2) (test (disjunktniPut1 graf (car cvoroviOD) odigraniPotez))) 't)
      (t (prsten graf (cdr cvoroviOD) odigraniPotez))
   )
)

(defun testSused (cvor cvor1)
   (cond
      ((and (equal (car cvor) (car cvor1)) (equal (cadr cvor) (1+ (cadr cvor1)))) 't)
      ((and (equal (car cvor) (car cvor1)) (equal (cadr cvor) (1- (cadr cvor1)))) 't)
      ((and (equal (indeks (car cvor) slova) (1- (indeks (car cvor1) slova))) (equal (cadr cvor) (cadr cvor1))) 't)
      ((and (equal (indeks (car cvor) slova) (1+ (indeks (car cvor1) slova))) (equal (cadr cvor) (cadr cvor1))) 't)
      ((and (equal (indeks (car cvor) slova) (1- (indeks (car cvor1) slova))) (equal (cadr cvor) (1- (cadr cvor1)))) 't)
      ((and (equal (indeks (car cvor) slova) (1+ (indeks (car cvor1) slova))) (equal (cadr cvor) (1+ (cadr cvor1)))) 't)
      ((equal cvor cvor1) 't)
      (t '())
   )
)

(defun disjunktniPut1 (graf start cilj)
  (cond 
      ((null graf) '())
      (:else (let* ((put1 (nadji-put graf  (list start) cilj '()))
                    (graf1 (ocisti graf (cdr (reverse (cdr put1))))))
               (cond ((null put1) '())
               ((< (length put1) 4) (disjunktniPut1 graf1 start cilj))
               (:else (cons put1 (disjunktniPut1 graf1 start cilj)))
               )
            )
      )
   )
)

(defun test1 (el lista2)
   (cond
      ((null lista2) 0)
      ((equal el (car lista2)) (test1 el (cdr lista2)))
      ((testSused el (car lista2)) (1+ (test1 el (cdr lista2))))
      (t (test1 el (cdr lista2)))
   )
)

(defun test2 (lista1 lista2)
   (cond 
      ((or (null lista1) (null lista2)) 't)
      ((<(test1 (car lista1) lista2) 2) (test2 (cdr lista1) lista2))
      (t '())
   )
)

(defun test3 (listaA)
   (cond
      ((null (cdr listaA)) '())
      ((equal (list(car listaA)) listaA) '())
      ((test2 (car listaA) (cadr listaA))  't)
      (t (test3(cons (car listaA) (cddr listaA))))
   )
)

(defun test(listaA)
   (cond 
      ((null listaA) '())
      ((test3 listaA) 'T)
      (t (test (cdr listaA)))
   )
)


;;odredjivanje svih mogucih buducih stanja iz trenutnog stanja ---------------------------------------------------------------------------------------------------------------------------------------------

(defun bms (trenutno broj XO)
   (if XO
      (cond
         ((null trenutno) '())
         ( (and(equal (car trenutno) '-) (equal broj 0)) (cons 'X (cdr trenutno)))
         ((equal (car trenutno) '-) (cons (car trenutno) (bms (cdr trenutno) (1- broj) XO)))
         (t (cons (car trenutno) (bms (cdr trenutno) broj XO)))
      )
      (cond
         ((null trenutno) '())
         ( (and(equal (car trenutno) '-) (equal broj 0)) (cons 'O (cdr trenutno)))
         ((equal (car trenutno) '-) (cons (car trenutno) (bms (cdr trenutno) (1- broj) XO)))
         (t (cons (car trenutno) (bms (cdr trenutno) broj XO)))
      )
   )
)

(defun brcrtica(stanje)
   (cond
      ((null stanje) 0)
      ((equal (car stanje) '-) (1+ (brcrtica (cdr stanje))))
      (t(brcrtica(cdr stanje)))
   )
)

(defun moguca (trenutno brS brB XO)
   (cond 
      ((= brB (brcrtica trenutno)) '())
      ((< brS brB) (moguca trenutno (1+ brS) brB XO))
      ((equal brS brB) (cons (bms trenutno brB XO) (moguca trenutno brS (1+ brB) XO)))
   )
)

;------------------------------------------------------------------------------Faza 3-------------------------------------------------------------------------------------------------------------------------

(defun igra-max(lp dubina alfa beta XO stanje)
   (cond
      ((null lp) (list stanje alfa))
      ( t 
         (let* ((min_stanje (minimax (car lp) (1- dubina) alfa beta  (not XO)))
         (na (apply 'max (list alfa (cadr min_stanje))))
         (novostanje (if (> na alfa)  (car lp) stanje)))
         (if (< na beta) (igra-max (cdr lp) dubina na beta XO novostanje) (list novostanje na)))
      )
   )
)        

(defun igra-min(lp dubina alfa beta XO stanje)
   (cond
      ((null lp) (list stanje beta))
      ( t 
         (let* ((max_stanje (minimax (car lp) (1- dubina) alfa beta  (not XO)))
         (nb (apply 'min (list beta (cadr max_stanje))))
         (novostanje (if (< nb beta) (car lp) stanje)))
         (if  (> nb alfa) (igra-min(cdr lp) dubina alfa nb  XO novostanje) (list novostanje nb) ))
      )
   )
)         

(defun minimax (stanje dubina alfa beta XO)
      (cond
      ((zerop dubina)  (list stanje (heuristika stanje XO)))
      (t   
         (setq lp (moguca stanje 0 0 XO))
         (cond 
            (( null lp)  (list stanje (heuristika stanje XO)))
            (t  (if XO (igra-max lp dubina alfa beta XO '()) (igra-min lp dubina alfa beta XO '())))
         )
      )
   )
)
	

;;(defun heuristika (stanje XO)
  ;; (cond
    ;;  (XO 100)
      ;;((not XO) -100)
   ;;)
;;)


(defun vratiPotez (stanje br1 br2)
   (cond
      ((null stanje) '())
      ((member (car stanje) slova) (vratiPotez (cdr stanje) (1+ br1) 0))
      ((and (equal 'O (car stanje)) (<= br1 (1- velicina))) 
                              (cond 
                                 ((ispitajCvorove (list (nth br1 slova) br2) (cvoroviGrafa1 grafO)) (vratiPotez (cdr stanje) br1 (1+ br2))) 
                                 (t (napraviGraf (nth br1 slova) br2 XO)  (listeIvica (nth br1 slova) br2 XO) (setq coske1 (odigraneCoske grafO)) (setq slovo (nth br1 slova)) (setq polje br2))
                              )
      )
      ((and (equal 'O (car stanje))(> br1 (1- velicina))) 
                              (cond 
                                 ((ispitajCvorove (list (nth br1 slova) (+ br2 (1+ (- br1 velicina)))) (cvoroviGrafa1 grafO)) (vratiPotez (cdr stanje) br1 (1+ br2))) 
                                 (t (napraviGraf (nth br1 slova) (+ br2 (1+ (- br1 velicina))) XO)  (listeIvica (nth br1 slova) (+ br2 (1+ (- br1 velicina))) XO) (setq coske1 (odigraneCoske grafO)) (setq slovo (nth br1 slova)) (setq polje (+ br2 (1+ (- br1 velicina)))))
                              )
      )
      ((equal '* (car stanje)) (vratiPotez (cdr stanje) br1 br2))
      (t (vratiPotez (cdr stanje) br1 (1+ br2)))
   )
)

;-------------------------------------------------------------------------------------------------------Faza 4---------------------------------------------------------------------------------------------------------

(defparameter *T1-RULES*
  '(	
     
       (if (and (X ?c ?d) (!eq ?c (- (* 2 velicina) 2)) (!eq ?d (- (* 2 velicina) 2))) then (coska_dole_desno) )
      (if (and (O ?c ?d) (!eq ?c (- (* 2 velicina) 2)) (!eq ?d (- (* 2 velicina) 2))) then (coska_dole_desno1))
      (if (and (X ?a ?b) (!eq ?b (1- velicina)) (!eq ?a 0)) then (coska_desno_gore) )
      (if (and (O ?a ?b) (!eq ?b (1- velicina)) (!eq ?a 0)) then (coska_desno_gore1) )
      (if (and (X ?c ?d) (!eq ?c (1- velicina)) (!eq ?d 0)) then (coska_sredina_levo) )
      (if (and (O ?c ?d) (!eq ?c (1- velicina)) (!eq ?d 0)) then (coska_sredina_levo1))
      (if (and (X ?c ?d) (!eq ?c (1- velicina)) (!eq ?d (- (* 2 velicina) 2))) then (coska_sredina_desno))
      (if (and (O ?c ?d) (!eq ?c (1- velicina)) (!eq ?d (- (* 2 velicina) 2))) then (coska_sredina_desno1))
      (if (and (X ?c ?d) (!eq ?c 0) (!eq ?d 0)) then (coska_gore_levo) )
      (if (and (O ?c ?d) (!eq ?c 0) (!eq ?d 0)) then (coska_gore_levo1))
      (if (and (X ?c ?d) (!eq ?c (- (* 2 velicina) 2)) (!eq ?d (1- velicina))) then (coska_dole_levo))
      (if (and (O ?c ?d) (!eq ?c (- (* 2 velicina) 2)) (!eq ?d (1- velicina))) then (coska_dole_levo1))

      (if (and  (X ?a ?b) (X ?c ?d) (O ?e ?f)  (!eq ?a ?c) (!eq ?d (1+ ?b)) (!eq ?e ?a) (!eq ?e ?c)  (!eq ?f (+ ?d 1))   (!eq ?f (+ ?b 2)) ) then  (blok_X1)) 
      (if (and  (O ?a ?b) (O ?c ?d) (X ?e ?f)  (!eq ?a ?c) (!eq ?d (1+ ?b)) (!eq ?e ?a) (!eq ?e ?c)  (!eq ?f (+ ?d 1))   (!eq ?f (+ ?b 2)) ) then  (blok_O1)) 
      (if (and  (O ?a ?b) (X ?c ?d) (X ?e ?f)  (!eq ?a ?c) (!eq ?d (1+ ?b)) (!eq ?e ?a) (!eq ?e ?c)  (!eq ?f (+ ?d 1))   (!eq ?f (+ ?b 2)) ) then  (blok_X2)) 
      (if (and  (X ?a ?b) (O ?c ?d) (O ?e ?f)  (!eq ?a ?c) (!eq ?d (1+ ?b)) (!eq ?e ?a) (!eq ?e ?c)  (!eq ?f (+ ?d 1))   (!eq ?f (+ ?b 2)) ) then  (blok_O2)) 

      (if (and  (O ?a ?b) (X ?c ?d) (X ?e ?f)  (!eq ?a (- ?c 1)) (!eq ?d ?b) (!eq ?e (+ 2 ?a)) (!eq ?e (+ 1 ?c))  (!eq ?f ?d)   (!eq ?f ?d) ) then  (blok_X3)) 
      (if (and  (X ?a ?b) (O ?c ?d) (O ?e ?f)  (!eq ?a (- ?c 1)) (!eq ?d ?b) (!eq ?e (+ 2 ?a)) (!eq ?e (+ 1 ?c))  (!eq ?f ?d)   (!eq ?f ?d) ) then  (blok_O3)) 
      (if (and  (X ?a ?b) (X ?c ?d) (O ?e ?f)  (!eq ?a (- ?c 1)) (!eq ?d ?b) (!eq ?e (+ 2 ?a)) (!eq ?e (+ 1 ?c))  (!eq ?f ?d)   (!eq ?f ?d) ) then  (blok_X4)) 
      (if (and  (O ?a ?b) (O ?c ?d) (X ?e ?f)  (!eq ?a (- ?c 1)) (!eq ?d ?b) (!eq ?e (+ 2 ?a)) (!eq ?e (+ 1 ?c))  (!eq ?f ?d)   (!eq ?f ?d) ) then  (blok_O4)) 

      (if (and  (O ?a ?b) (X ?c ?d) (X ?e ?f)  (!eq ?a (- ?c 1)) (!eq ?d (+ 1 ?b)) (!eq ?e (+ 2 ?a)) (!eq ?e (+ 1 ?c))  (!eq ?f (+ 1 ?d))   (!eq ?f (+ 1 ?d)) ) then  (blok_X5)) 
      (if (and  (X ?a ?b) (O ?c ?d) (O ?e ?f)  (!eq ?a (- ?c 1)) (!eq ?d (+ 1 ?b)) (!eq ?e (+ 2 ?a)) (!eq ?e (+ 1 ?c))  (!eq ?f (+ 1 ?d))   (!eq ?f (+ 1 ?d)) ) then  (blok_O5)) 
      (if (and  (X ?a ?b) (X ?c ?d) (O ?e ?f)  (!eq ?a (- ?c 1)) (!eq ?d (+ 1 ?b)) (!eq ?e (+ 2 ?a)) (!eq ?e (+ 1 ?c))  (!eq ?f (+ 1 ?d))   (!eq ?f (+ 1 ?d)) ) then  (blok_X6)) 
      (if (and  (O ?a ?b) (X ?c ?d) (X ?e ?f)  (!eq ?a (- ?c 1)) (!eq ?d (+ 1 ?b)) (!eq ?e (+ 2 ?a)) (!eq ?e (+ 1 ?c))  (!eq ?f (+ 1 ?d))   (!eq ?f (+ 1 ?d)) ) then  (blok_O6)) 

      (if (and  (X ?a ?b) (O ?c ?d) (X ?e ?f)  (!eq ?a (- ?c 1)) (!eq ?d ?b) (!eq ?e (+ 2 ?a)) (!eq ?e (+ 1 ?c))  (!eq ?f (+ 1 ?d)) ) then  (blok_X7)) 
      (if (and  (O ?a ?b) (X ?c ?d) (O ?e ?f)  (!eq ?a (- ?c 1)) (!eq ?d ?b) (!eq ?e (+ 2 ?a)) (!eq ?e (+ 1 ?c))  (!eq ?f (+ 1 ?d)) ) then  (blok_O7)) 
      (if (and  (X ?a ?b) (O ?c ?d) (X ?e ?f)  (!eq ?a (- ?c 1)) (!eq ?d (+ 1 ?b)) (!eq ?e (+ 2 ?a)) (!eq ?e (+ 1 ?c))  (!eq ?f ?d) ) then  (blok_X8)) 
      (if (and  (O ?a ?b) (X ?c ?d) (O ?e ?f)  (!eq ?a (- ?c 1)) (!eq ?d (+ 1 ?b)) (!eq ?e (+ 2 ?a)) (!eq ?e (+ 1 ?c))  (!eq ?f ?d) ) then  (blok_O8)) 

      
      (if (and  (X ?a ?b) (X ?c ?d) (O ?e ?f)  (!eq ?a ?c) (!eq ?d (+ ?b 1)) (!eq ?e (- ?a 1)) (!eq ?e (- ?c 1))  (!eq ?f (- ?d 1)) ) then  (blok_X9)) 
      (if (and  (O ?a ?b) (O ?c ?d) (X ?e ?f)  (!eq ?a ?c) (!eq ?d (+ ?b 1)) (!eq ?e (- ?a 1)) (!eq ?e (- ?c 1))  (!eq ?f (- ?d 1)) ) then  (blok_O9)) 
      (if (and  (X ?a ?b) (X ?c ?d) (O ?e ?f)  (!eq ?a ?c) (!eq ?d (+ 1 ?b)) (!eq ?e (+ 1 ?a))  (!eq ?f ?d) ) then  (blok_X10)) 
      (if (and  (O ?a ?b) (O ?c ?d) (X ?e ?f)  (!eq ?a ?c) (!eq ?d (+ 1 ?b)) (!eq ?e (+ 1 ?a))  (!eq ?f ?d) ) then  (blok_O10)) 

      (if (and  (X ?a ?b) (O ?c ?d) (X ?e ?f)  (!eq ?a ?c) (!eq ?d (+ ?b 1)) (!eq ?e ?a ) (!eq ?e ?c )  (!eq ?f (+ ?d 1)) ) then  (blok_X11)) 
      (if (and  (O ?a ?b) (X ?c ?d) (O ?e ?f)  (!eq ?a ?c) (!eq ?d (+ ?b 1)) (!eq ?e ?a ) (!eq ?e ?c )  (!eq ?f (+ ?d 1)) ) then  (blok_O11))
      
      (if (X ?a ?b) then (figura_X))
      (if (O ?a ?b) then (figura_O))
   )
)

(defun heuristika ( stanje XO)
   (setq *T1-FACTS* (vratiPotez1 stanje -1 0))
   (prepare-knowledge *T1-RULES* *T1-FACTS* 2)
   (cond 
      (XO (-
         (+ (* (count-results '(figura_X)) 0.5) (* (count-results '(blok_O11)) 8.5) (* (count-results '(blok_O10)) 8.1) (* (count-results '(blok_O9)) 8.1) (* (count-results '(blok_O8)) 8) (* (count-results '(blok_O7)) 8)  (* (count-results '(blok_O6)) 7) (* (count-results '(blok_O5)) 6) (* (count-results '(blok_O4)) 7) (* (count-results '(blok_O3)) 6) (* (count-results '(blok_O2)) 7) (* (count-results '(blok_O1)) 6) (* (count-results '(coska_desno_gore)) 5)  (* (count-results '(coska_sredina_levo)) 5)   (* (count-results '(coska_sredina_desno)) 5)  (* (count-results '(coska_gore_levo)) 5) (* (count-results '(coska_dole_desno)) 5) (* (count-results '(coska_dole_levo)) 5) )
         (+ (* (count-results '(figura_O)) -0.5) (* (count-results '(blok_X11)) -8.5) (* (count-results '(blok_X10)) -8.1) (* (count-results '(blok_X9)) -8.1) (* (count-results '(blok_X8)) -8) (* (count-results '(blok_X7)) -8) (* (count-results '(blok_X6)) -7) (* (count-results '(blok_X5)) -6) (* (count-results '(blok_X4)) -7) (* (count-results '(blok_X3)) -6) (* (count-results '(blok_X2)) -7) (* (count-results '(blok_X1)) -6) (* (count-results '(coska_desno_gore1)) -5) (* (count-results '(coska_sredina_levo1)) -5)   (* (count-results '(coska_sredina_desno1)) -5)  (* (count-results '(coska_gore_levo1)) -5) (* (count-results '(coska_dole_desno1)) -5) (* (count-results '(coska_dole_levo1)) -5) )
         ))
      ((not XO) 
          (+
          (+ (* (count-results '(figura_O)) -0.5) (* (count-results '(blok_X11)) -8.5) (* (count-results '(blok_X10)) -8.1) (* (count-results '(blok_X9)) -8.1) (* (count-results '(blok_X8)) -8) (* (count-results '(blok_X7)) -8) (* (count-results '(blok_X6)) -7) (* (count-results '(blok_X5)) -6) (* (count-results '(blok_X4)) -7) (* (count-results '(blok_X3)) -6) (* (count-results '(blok_X2)) -7) (* (count-results '(blok_X1)) -6) (* (count-results '(coska_desno_gore1)) -5) (* (count-results '(coska_sredina_levo1)) -5)   (* (count-results '(coska_sredina_desno1)) -5)  (* (count-results '(coska_gore_levo1)) -5) (* (count-results '(coska_dole_desno1)) -5) (* (count-results '(coska_dole_levo1)) -5) )
           (+ (* (count-results '(figura_X)) 0.5) (* (count-results '(blok_O11)) 8.5) (* (count-results '(blok_O10)) 8.1) (* (count-results '(blok_O9)) 8.1) (* (count-results '(blok_O8)) 8) (* (count-results '(blok_O7)) 8) (* (count-results '(blok_O6)) 7) (* (count-results '(blok_O5)) 6) (* (count-results '(blok_O4)) 7) (* (count-results '(blok_O3)) 6) (* (count-results '(blok_O2)) 7) (* (count-results '(blok_O1)) 6) (* (count-results '(coska_desno_gore)) 5)  (* (count-results '(coska_sredina_levo)) 5)   (* (count-results '(coska_sredina_desno)) 5)  (* (count-results '(coska_gore_levo)) 5) (* (count-results '(coska_dole_desno)) 5) (* (count-results '(coska_dole_levo)) 5) )
          )
      
      )
   
   )
 
)

(defun vratiPotez1 (stanje br1 br2)
  (cond 
     ((null stanje) '())
      ((member (car stanje) slova) (vratiPotez1 (cdr stanje) (1+ br1) 0))
      ((and (equal 'O (car stanje)) (<= br1 (1- velicina))) (cons (cons 'O (cons  br1  (list br2 )) ) (vratiPotez1 (cdr stanje) br1 (1+ br2))) )
      ((and (equal 'X (car stanje)) (<= br1 (1- velicina))) (cons (cons 'X (cons br1 (list br2 ))) (vratiPotez1 (cdr stanje) br1 (1+ br2))) )
      ((and (equal 'X (car stanje))(> br1 (1- velicina))) (cons (cons 'X (cons br1 (list (+ br2 (1+ (- br1 velicina))) ))) (vratiPotez1 (cdr stanje) br1 (1+ br2))) )
      ((and (equal 'O (car stanje))(> br1 (1- velicina))) (cons (cons 'O (cons br1 (list (+ br2 (1+ (- br1 velicina))) ))) (vratiPotez1 (cdr stanje) br1 (1+ br2))) )
      ((equal '* (car stanje)) (vratiPotez1 (cdr stanje) br1 br2))
      (t (vratiPotez1 (cdr stanje) br1 (1+ br2)))
  )
)



; PREDEFINI operator 

(defun !eq (a b)
  (equalp a b))



                                                      ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
                                                      ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
                                                      ;;;;;                                                                                                ;;;;;
                                                      ;;;;;                                       INFERENCE ENGINE                                         ;;;;;
                                                      ;;;;;                                                                                                ;;;;;
                                                      ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
                                                      ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; POMOCNE FUNKCIJE

;; provera da li je parametar s izvorna promenljiva (simbol koji pocinje coska_dole_desno ?)
(defun true-var? (s) 
  (if (symbolp s)
      (equal #\? (char (symbol-name s) 0))
    nil))

;; provera da li je parametar s promenljiva (simbol koji pocinje coska_dole_desno ? ili %)
(defun var? (s) 
  (if (symbolp s)
      (let ((c (char (symbol-name s) 0)))
        (or (equal c #\?) (equal c #\%)))
    nil))

;; provera da li je parametar s funkcija (simbol koji pocinje coska_dole_desno =)
(defun func? (s) 
  (if (symbolp s)
      (equal #\= (char (symbol-name s) 0))
    nil))

;; provera da li je parametar s predefinicoska_dole_desnoni predikat (simbol koji pocinje coska_dole_desno !)
(defun predefined-predicate? (s)
  (if (symbolp s)
      (equal #\! (char (symbol-name s) 0))
    nil))

;; provera da li je parametar s konstanta (ako nije promenljiva ili funkcija onda je konstanta)
(defun const? (s)
  (not (or (var? s) (func? s))))

;; rekurzivna provera da li je parametar f funkcija od parametra x
(defun func-of (f x)
  (cond
   ((null f) ; kraj rekurzije
    t)
   ((atom f)
    (equal f x))
   (t
    (or (func-of (car f) x) (func-of (cdr f) x)))))

;; provera da li funkcija f ima promenljivih
(defun has-var (f)
  (cond
   ((null f) 
    nil)
   ((atom f)
    (var? f))
   (t
    (or (has-var (car f)) (has-var (cdr f))))))

;; funkcija koja vraca konsekvencu pravila
(defun rule-consequence (r)
  (car (last r)))

;; funkcija koja vraca premisu pravila
(defun rule-premises (r)
  (let ((p (cadr r)))
    (if (and (listp p) (equal (car p) 'and))
        (cdr p)
      (list p))))
      
;; funkcija koja vrsi prebacivanje upita u interni format (izbacuje 'and)
(defun format-query (q)
  (if (and (listp q) (equal (car q) 'and))
      (cdr q)
    (list q)))
    
;; izracunavanje istinitosne vrednosti predefinicoska_dole_desnonog predikata
(defun evaluate-predicate (p ls)
  (if (has-var p) nil  ; ako poseduje slobodne promenljive vraca nil (nije validna situacija)
    (if (eval p) 
        (list ls) ; ako predikat vazi vraca ulaznu listu smena
      nil))) ; u suprotnom vraca nil

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; INTERFEJSNE FUNKCIJE I GLOBALNE PROMENLJIVE

(defparameter *FACTS* nil)
(defparameter *RULES* nil)
(defparameter *MAXDEPTH* 10)

;; priprema *FACTS*, *RULES* i *MAXDEPTH*
(defun prepare-knowledge (lr lf maxdepth)
  (setq *FACTS* lf *RULES* (fix-rules lr) *MAXDEPTH* maxdepth))

;; vraca broj rezulata izvodjenja
(defun count-results (q)
  (length (infer- (format-query q) '(nil) 0)))

;; vraca listu lista smena
(defun infer (q)
  (filter-resultss (infer- (format-query q) '(nil) 0)))

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; FUNKCIJE KOJE VRSE DODELU NOVIH JEDINSTVENIH PROMENLJIVIH PRAVILIMA

(defun fix-rules (lr)
  (if (null lr) nil
    (cons (fix-rule (car lr)) (fix-rules (cdr lr)))))

(defun fix-rule (r)
  (let ((ls (make-rule-ls r nil)))
    (apply-ls r ls)))

(defun make-rule-ls (r ls)
  (cond
   ((null r)
    ls)
   ((var? r)
    (let ((a (assoc r ls)))
      (if (null a)
          (cons (list r (gensym "%")) ls)
        ls)))
   ((atom r)
    ls)   
   (t
    (make-rule-ls (cdr r) 
                  (make-rule-ls (car r) ls)))))

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; FUNKCIJE KOJE VRSE PRIPREMU REZULTATA (IZBACUJU SMENE KOJE SE ODNOSE NA INTERNE PROMENLJIVE)

(defun filter-resultss (lls)
  (if (null lls) nil
    (cons (filter-results (car lls)) (filter-resultss (cdr lls)))))

(defun filter-results (ls)
  (if (null ls) nil
    (if (true-var? (caar ls))
        (cons (car ls) (filter-results (cdr ls)))
      (filter-results (cdr ls)))))

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; FUNKCIJE KOJE SE KORISTE U IZVODJENJU

;; glavna funkcija za izvodjenje, vraca listu lista smena
;; lq - predikati upita
;; lls - lista listi smena (inicijalno lista koja coska_dole_desnodrzi nil)
;; depth - tekuca dubina (inicijalno 0)
(defun infer- (lq lls depth)
  (if (null lq) lls
    (let ((lls-n (infer-q (car lq) lls depth)))
      (if (null lls-n) nil
        (infer- (cdr lq) lls-n depth)))))

;; izvodjenje za jedan predikat iz upita, vraca listu lista smena
(defun infer-q (q lls depth)
  (if (null lls) nil
    (let ((lls-n (infer-q-ls q (car lls) depth)))
      (if (null lls-n)
          (infer-q q (cdr lls) depth)
        (append lls-n (infer-q q (cdr lls) depth))))))

;; izvodjenje za jedan predikat coska_dole_desno jednom listom smena, vraca listu lista smena
(defun infer-q-ls (q ls depth)
  (if (predefined-predicate? (car q))
      (evaluate-predicate (apply-ls q ls) ls)
    (if (< depth *MAXDEPTH*)
        (append (infer-q-ls-lf q *FACTS* ls) (infer-q-ls-lr q *RULES* ls depth))
      (infer-q-ls-lf q *FACTS* ls))))
      
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

;; izvodjenje nad bazom cinjenica lf, vraca listu lista smena
(defun infer-q-ls-lf (q lf ls)
  (if (null lf) nil
    (let ((ls-n (infer-q-ls-f q (car lf) ls)))
      (if (null ls-n)
          (infer-q-ls-lf q (cdr lf) ls)
        (if (null (car ls-n)) ls-n
          (append ls-n (infer-q-ls-lf q (cdr lf) ls)))))))

;; izvodjenje coska_dole_desno jednom cinjenicom, vraca listu coska_dole_desno listom smena
(defun infer-q-ls-f (q f ls)
  (if (= (length q) (length f)) ; provera na istu duzinu
      (infer-q-ls-f- q f ls)
    nil))

;; izvodjenje coska_dole_desno jednom cinjenicom, vraca listu coska_dole_desno listom smena
(defun infer-q-ls-f- (q f ls)
  (if (null q) (list ls)
    (let ((nq (apply-and-eval (car q) ls)) (nf (car f)))
      (if (var? nq) 
          (infer-q-ls-f- (cdr q) (cdr f) (append ls (list (list nq nf))))
        (if (equal nq nf) 
            (infer-q-ls-f- (cdr q) (cdr f) ls)
          nil)))))
          
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

;; izvodjenje nad bazom pravila, vraca listu lista smena
(defun infer-q-ls-lr (q lr ls depth)
  (if (null lr) nil
    (let ((ls-n (infer-q-ls-r q (car lr) ls depth)))
      (if (null ls-n)
          (infer-q-ls-lr q (cdr lr) ls depth)
        (if (null (car ls-n)) ls-n
          (append ls-n (infer-q-ls-lr q (cdr lr) ls depth)))))))

;; izvodjenje coska_dole_desno jednim pravilom, vraca listu coska_dole_desno listom smena
(defun infer-q-ls-r (q r ls depth)
  (let ((c (rule-consequence r)))
    (if (= (length q) (length c))
        (let ((lsc (unify q c nil ls)))
          (if (null lsc) nil
            (infer- (apply-ls (rule-premises r) (car lsc)) (cdr lsc) (1+ depth))))
      nil)))

;; unifikacija predikata upita q i konsekvence pravila c primenom liste smena ls, vraca listu smena
(defun unify (q c uls ls)
  (if (or (null q) (null c))
      (if (and (null q) (null c)) (list uls ls) nil)
    (let ((eq (car q)) (ec (car c)))
      (cond
       ((equal eq ec)
        (unify (cdr q) (cdr c) uls ls))
       ((var? eq)
        (cond
         ((var? ec)
          (let ((a (assoc ec uls)))
            (cond
             ((null a)              
              (unify (cdr q) (cdr c) (cons (list ec eq) uls) ls))
             ((equal (cadr a) eq)
              (unify (cdr q) (cdr c) uls ls))
             (t
              nil))))
         ((func? ec)
          nil)
         (t ;; const
          (let ((a (assoc eq ls)))
            (cond
             ((null a)
              (unify (cdr q) (cdr c) uls (cons (list eq ec) ls)))
             ((equal (cadr a) ec)
              (unify (cdr q) (cdr c) uls ls))
             (t 
              nil))))))
       ((func? eq)
        (cond
         ((var? ec)
          (if (func-of eq ec) nil
            (let ((a (assoc ec uls)))
              (cond
               ((null a)              
                (unify (cdr q) (cdr c) (cons (list ec eq) uls) ls))
               ((equal (cadr a) eq)
                (unify (cdr q) (cdr c) uls ls))
               (t
                nil)))))
         ((func? ec)
          nil)
         (t ;; const
          (let ((f (apply-ls eq ls)))
            (if (has-var f) nil
              (if (equal (eval f) ec)
                  (unify (cdr q) (cdr c) uls ls)
                nil))))))
       (t ;; const
        (cond
         ((var? ec)
          (let ((a (assoc ec uls)))
            (cond
             ((null a)              
              (unify (cdr q) (cdr c) (cons (list ec eq) uls) ls))
             ((equal (cadr a) eq)
              (unify (cdr q) (cdr c) uls ls))
             (t
              nil))))
         (t ;; func or const
          nil)))))))

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; PRIMENA LISTE SMENA I IZRACUNAVANJE IZRAZA

(defun apply-and-eval (x ls)
  (if (var? x)
      (apply-ls x ls)
    (if (and (listp x) (func? (car x)))
        (eval (apply-ls x ls)) 
      x)))

;; primena liste smena ls na izraz x
(defun apply-ls (x ls)
  (cond
   ((null x)
    x)
   ((var? x)
    (let ((ax (assoc x ls)))
      (if (null ax) x
        (cadr ax))))
   ((atom x)
    x)
   (t
    (cons (apply-ls (car x) ls) (apply-ls (cdr x) ls)))))