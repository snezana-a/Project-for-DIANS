#!/bin/bash

#FILTER2: Filtriranje na site kafici koi se na max 1km odaleceni
#presmetka za dali kaficot e na 1-1.5km do plostadot vo skopje
function presmetka(){

lat=419953933
lon=214315704

presmetka=`echo "$(($dolzina_lon - $lon))"`
if [ ${presmetka} -ge -800000 ] && [ ${presmetka} -le 800000 ]; then
	return ${presmetka}
fi

presmetka2=`echo "$(($dolzina_lat - $lat))"`
if [ $presmetka2 -ge -800000 ] && [ $presmetka -le 800000 ]; then
	return  ${presmetka2}
fi

return -1
}

IFS=$'\n'

#koristenje pipeline koncent za da gi prezememe sekoj red vo
#sleden element od nizata site_podatoci
site_podatoci=$(cat $1 |tr "\n" "\n")
site_podatoci_niza=($site_podatoci)

#opredeleuvanje na dolzinata za iteriranje vo nizata
size=${#site_podatoci_niza[@]}

#definiranje novi nizi za dolzinite (da filtrirame najbiski do centar) i iminjata
site_dolzini=()
site_iminja=()
j=0

#iteriranje po sekoj red vo podatocite od mapata
for (( i=1100; i<${size}; i++));
do
	#zimanje na momentalniot red
	red="${site_podatoci_niza[$i]}"
	#proverka dali redot se odnesuva za kafic
	#FILTER1: se zimaat site kafici
	if [[ ${red} =~ cafe ]]; then
		#vo slednite 2while ciklusi barame nagore i nadole da gi zememe
		#dolzinite i iminjata na kaficite
		ip1=i
		cafe_name="${site_podatoci_niza[$ip1]}"
		while ! [[ ${cafe_name} =~ name ]]
		do
			ip1=$((ip1+1))
   			cafe_name="${site_podatoci_niza[$ip1]}"
		done
		ip2=i
                cafe_location="${site_podatoci_niza[$ip2]}"
                while ! [[ ${cafe_location} =~ node|way ]]
                do
                        ip2=$((ip2-1))
                        cafe_location="${site_podatoci_niza[$ip2]}"
                done

		#so pipeline konceptot go zacuvuvame imeto na kaficot vo ime_kafic
		ime_kafic=`echo $cafe_name | awk '{print $3}'`

		#so pipeline konceptto gi zimame lon i lat dolzinite za potoa da presmetame
                #odalecnost od centarot
		if [[ ${cafe_location} =~ node ]]; then
			del1=`echo $cafe_location | awk '{print $10}' | awk -F '"' '{print $2}' | awk -F '.' '{print $1}'`
                	del2=`echo $cafe_location | awk '{print $10}' | awk -F '"' '{print $2}' | awk -F '.' '{print $2}'`
			dolzina_lon=$del1$del2

			del1=`echo $cafe_location | awk '{print $9}' | awk -F '"' '{print $2}' | awk -F '.' '{print $1}'`
			del2=`echo $cafe_location | awk '{print $9}' | awk -F '"' '{print $2}' | awk -F '.' '{print $1}'`

			dolzina_lat=$del1$del2
		else
			dolzina_lat=100000000
			dolzina_lon=100000000
		fi

		presmetka
		flag=$?

		#dokolku flag > 0 t.e. dokolku funkcijata presmetka vrati rastojanie
		#a dokolku vrati ke vrati > 1km toa znaci deka kaficot go pominuva
		#filterot i go stavame vo nizata na iminja isto i negovata oddalecenost
		if [ ${flag} -gt 0 ]; then
			ime_kafic=`echo $ime_kafic | awk -F '"' '{print $2}'` 	
			site_iminja+=("${ime_kafic}")
			site_dolzini+=("${flag}")
		fi
	fi

done

#gi stavame site vo niza odeleni so ,
#so sto vo prateniot falj kako argument na
#funkcijata generairame csv fajl vo koj se smesteni
#site zapisi i potoa ke go koristime vo finalnata app
`echo "ID,Ime_Kafic,Rastojanie_Centar" >> $2`
for (( i=0; i<${#site_iminja[@]}; i++ )); do
	vnes=$i",""${site_iminja[$i]}"",""${site_dolzini[$i]}"
	`echo $vnes >> $2`
done

#vo finalniot file sto go isprativme kako argument
#gi imame site zapisi
