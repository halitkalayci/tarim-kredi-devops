FROM node:20 AS build-stage

WORKDIR /app

COPY package.json package-lock.json ./

RUN npm install

COPY . .

RUN npm run build -- --configuration production

FROM nginx:alpine AS production-stage

COPY --from=build-stage /app/dist/example-client/browser  /usr/share/nginx/html

COPY nginx.conf /etc/nginx/conf.d/default.conf

CMD ["nginx", "-g", "daemon off;"]
