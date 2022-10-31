FROM alpine
RUN apk add --no-cache python3
RUN mkdir /root/app
WORKDIR /root/app
COPY ./server/server.py .
EXPOSE 8080
CMD ["python3","/root/app/server.py"]