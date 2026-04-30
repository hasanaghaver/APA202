document.body.style.backgroundColor = "lightgray";  // cartin gorunmesi ucun bu rengi verdim.

let cart = document.createElement("div");
cart.style.width = "300px";
cart.style.height = "auto";
cart.style.backgroundColor = "white";
cart.style.borderRadius = "10px";
cart.style.position = "relative";
document.body.appendChild(cart);

let love = document.createElement("i");
love.className = "fa-regular fa-heart";
love.style.fontSize = "20px";
love.style.color = "white";
love.style.top = "20px";
love.style.right = "15px";
love.style.position = "absolute";
cart.appendChild(love);

let image = document.createElement("img");
image.src = "https://picsum.photos/200/300";
image.style.width = "100%";
image.style.height = "200px";
image.style.borderRadius = "10px 10px 0px 0px";
cart.appendChild(image);

let title = document.createElement("h2");
title.innerText = "DETACHED HOUSE . 5Y OLD";
title.style.fontSize = "13px";
title.style.fontFamily = "Arial, Helvetica, sans-serif";
title.style.fontWeight = "760";
title.style.marginLeft = "10px";
title.style.color = "#4a5568";
cart.appendChild(title);

let price = document.createElement("p");
price.innerText = "$750.000";
price.style.fontSize = "25px";
price.style.fontFamily = "Arial, Helvetica, sans-serif";
price.style.color = "black";
price.style.margin = "0px 10px 0px 10px";
cart.appendChild(price);

let locat = document.createElement("p");
locat.innerText = "742 Evergreen Terrace";
locat.style.fontSize = "14px";
locat.style.fontFamily = "Arial, Helvetica, sans-serif";
locat.style.color = "gray";
locat.style.margin = "6px 10px";
cart.appendChild(locat);

let line = document.createElement("hr");
line.style.border = "0.5px solid #e2e8f0";
line.style.margin = "10px 0px";
cart.appendChild(line);

let features = document.createElement("div");
features.style.display = "flex";
features.style.justifyContent = "space-around";
features.style.margin = "10px 0px";
cart.appendChild(features);

let bedroomDiv = document.createElement("div");
bedroomDiv.style.display = "flex";
bedroomDiv.style.alignItems = "center";
features.appendChild(bedroomDiv);

let bedroomIcon = document.createElement("i");
bedroomIcon.className = "fa-solid fa-bed";
bedroomIcon.style.fontSize = "20px";
bedroomIcon.style.color = "#4a5568";
bedroomDiv.appendChild(bedroomIcon);

let bedroomCount = document.createElement("p");
bedroomCount.innerText = "3";
bedroomCount.style.fontSize = "14px";
bedroomCount.style.fontWeight = "600";
bedroomCount.style.fontFamily = "Arial, Helvetica, sans-serif";
bedroomCount.style.color = "black";
bedroomCount.style.marginLeft = "5px";
bedroomDiv.appendChild(bedroomCount);

let bedroomText = document.createElement("p");
bedroomText.innerText = "Bedrooms";
bedroomText.style.fontSize = "14px";
bedroomText.style.fontFamily = "Arial, Helvetica, sans-serif";
bedroomText.style.color = "gray";
bedroomText.style.marginLeft = "5px";
bedroomDiv.appendChild(bedroomText);

let bathroomDiv = document.createElement("div");
bathroomDiv.style.display = "flex";
bathroomDiv.style.alignItems = "center";
features.appendChild(bathroomDiv);

let bathroomIcon = document.createElement("i");
bathroomIcon.className = "fa-solid fa-bath";
bathroomIcon.style.fontSize = "20px";
bathroomIcon.style.color = "#4a5568";
bathroomDiv.appendChild(bathroomIcon);

let bathroomCount = document.createElement("p");
bathroomCount.innerText = "2";
bathroomCount.style.fontSize = "14px";
bathroomCount.style.fontWeight = "600";
bathroomCount.style.fontFamily = "Arial, Helvetica, sans-serif";
bathroomCount.style.color = "black";
bathroomCount.style.marginLeft = "5px";
bathroomDiv.appendChild(bathroomCount);

let bathroomText = document.createElement("p");
bathroomText.innerText = "Bathrooms";
bathroomText.style.fontSize = "14px";
bathroomText.style.fontFamily = "Arial, Helvetica, sans-serif";
bathroomText.style.color = "gray";
bathroomText.style.marginLeft = "5px";
bathroomDiv.appendChild(bathroomText);

let secondLine = document.createElement("hr");
secondLine.style.border = "0.5px solid #e2e8f0";
secondLine.style.margin = "0px";
cart.appendChild(secondLine);


let realtorDiv = document.createElement("div");
realtorDiv.style.width = "100%";
realtorDiv.style.height = "auto";
realtorDiv.style.display = "flex";
realtorDiv.style.alignItems = "center";
realtorDiv.style.flexWrap = "wrap";
realtorDiv.style.backgroundColor = "#f7fafc";
realtorDiv.style.paddingBottom = "20px";
realtorDiv.style.borderRadius = "0px 0px 10px 10px";
cart.appendChild(realtorDiv);

let realtor = document.createElement("p");
realtor.style.width = "100%"
realtor.innerText = "REALTOR";
realtor.style.marginLeft = "10px";
realtor.style.fontSize = "14px";
realtor.style.fontFamily = "Arial, Helvetica, sans-serif";
realtor.style.fontWeight = "550";
realtor.style.color = "#718096";
realtorDiv.appendChild(realtor);

let realtorImage = document.createElement("img");
realtorImage.src = "https://picsum.photos/id/237/200/300";
realtorImage.style.width = "50px";
realtorImage.style.height = "50px";
realtorImage.style.borderRadius = "50%";
realtorImage.style.marginLeft = "10px";
realtorDiv.appendChild(realtorImage);

let realtorInfo = document.createElement("div");
realtorInfo.style.display = "flex";
realtorInfo.style.flexDirection = "column";
realtorInfo.style.marginLeft = "10px";
realtorDiv.appendChild(realtorInfo);

let realtorName = document.createElement("p");
realtorName.innerText = "Tiffany Heffner";
realtorName.style.fontSize = "14px";
realtorName.style.fontWeight = "600";
realtorName.style.fontFamily = "Arial, Helvetica, sans-serif";
realtorName.style.color = "black";
realtorName.style.margin = "0px 0px 5px 0px";
realtorInfo.appendChild(realtorName);

let realtorPhone = document.createElement("p");
realtorPhone.innerText = "(555) 555-4321";
realtorPhone.style.fontSize = "14px";
realtorPhone.style.fontFamily = "Arial, Helvetica, sans-serif";
realtorPhone.style.color = "gray";
realtorPhone.style.margin = "0px 0px 0px 0px";
realtorInfo.appendChild(realtorPhone);