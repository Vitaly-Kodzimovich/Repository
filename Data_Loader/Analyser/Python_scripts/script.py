from transformers import pipeline
from googletrans import Translator, constants
from pprint import pprint
import os

translator = Translator()
#translation = translator.translate("Hola Mundo")
analyzer = pipeline("sentiment-analysis")
#print(f"{translation.text}")

news_file = open(os.path.realpath(__file__).split("script.py")[0] + "NewsNames.txt")
analysed_data_file = open(os.path.realpath(__file__).split("script.py")[0] + "Analysed_Data.txt",'a')

news_to_analyse = news_file.readlines()
for news_page in news_to_analyse:
    translation = translator.translate(news_page.split("###")[1])
    positivity_of_newspage = analyzer(translation.text)
    if(str(positivity_of_newspage[0].get("label")) == "POSITIVE"):
        analysed_data_file.write(str(news_page.split("###")[0] + "###" + "1" + "\n"))
    else:
        analysed_data_file.write(str(news_page.split("###")[0] + "###" + "0" + "\n"))



