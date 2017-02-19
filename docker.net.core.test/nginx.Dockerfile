FROM nginx:latest

# Copy custom nginx config
COPY ./Config/nginx.development.conf /etc/nginx/nginx.conf

# Copy custom nginx config
# COPY ./public /var/www/public

EXPOSE 8000

ENTRYPOINT ["nginx"]
CMD ["-g", "daemon off;"]
 