#include <iostream>
#include <fstream>
#include <cstdlib>
#include <cmath>
#include <ctime>
#include <memory>
#include <vector>

class Generator final {
public:

    Generator() {
        std::cout << "target: " << this->target_;
        this->generateData();
    }

    Generator(int amount){
        this->generateData(amount);

        for(int i = 0; i < amount; i++) {

        }

    }


private:

    void generateData(){
        std::ofstream file(this->target_);
        int collums = 50;

       std::vector<std::string> Cities = {
        "NYC", "London", "Canada", "California"
       };

        std::vector<std::string> titles = {
            "City", "Amount", "Victim"
        };

        for(const auto &title : titles) {
            file << title;
            file << ",";
        }
        file << std::endl;

        for(int i = 0; i < collums; i++){
            file << Cities[std::rand() % (Cities.size() - 1)]; file << ",";
            file << std::rand() % (10 - 1); file << ",";

            if(int a = std::rand() % 2 - 1 == 0){ file << "MALE"; file << ","; }
            else { file << "FEMALE"; file << ","; }
            file << std::endl;
        }


        this->execute();
    }
    void generateData(int &am){
        std::ofstream file(this->target_, std::ofstream::app);

        this->execute();
    }

    void execute(){
        int res = std::system(std::string("python main.py").c_str());
        
        if(!res) {
            std::cout << "Something went wrong" << std::endl;
        }else {
            std::cout << "Execute python script" << std::endl;
        }
    }

    const std::string target_ = "data.csv";

};


int main(){
    std::srand(std::time(nullptr));
    auto un = std::make_unique<Generator>();
}