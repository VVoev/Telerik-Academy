			---------------1-----------------
			return products.map(p=>p.productType)
                .sort()
                .filter((p,i,ps)=> i===0 || p!==ps[i-1]);
            //Vzema samo unikalnite elementi i gi buta v masiv]
			
			
			---------------2-----------------
			let cost = products.reduce((cost,product)=>cost+ product.price,0);
			//Smqta stoinostta na vsichki produkti v masiva ili vrushta 0 ako nqma takiva
			
