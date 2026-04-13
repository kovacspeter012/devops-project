FROM node:24 AS build

WORKDIR .
COPY . .
RUN npm i
RUN npm run build

FROM httpd AS final
COPY --from=build /dist/angular/browser /usr/local/apache2/htdocs